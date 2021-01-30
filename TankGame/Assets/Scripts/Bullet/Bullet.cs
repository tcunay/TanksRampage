using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof (Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] protected GameObject ExplosionAudio;
    [SerializeField] protected GameObject MissAudio;
    [SerializeField] protected GameObject HitPlayerAudio;
    [SerializeField] protected ParticleSystem ExplosionEffect;
    [SerializeField] protected ParticleSystem HittingTheGround;
    [SerializeField] protected int Damage = 1;

    public UnityAction ToastyActive;


    protected bool OwnedByPlayer = false;
    protected float Delay = 5f;

    public void DestroyBullet(float delay)
    {
        Destroy(gameObject, delay);
    }
    public void InstallForPlayer()
    {
        OwnedByPlayer = true;
    }

    public void ProcessHit(Enemy enemy, Player player)
    {
        enemy?.ApplyDamage(Damage);
        player?.ApplyDamage(Damage);
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        DestroyBullet(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (OwnedByPlayer && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            ProcessHit(enemy, null);
            var explosionAudio = Instantiate(ExplosionAudio);
            Destroy(explosionAudio, 5);
            return;
        }
        else if (!OwnedByPlayer && collision.gameObject.TryGetComponent(out Player player))
        {
            ProcessHit(null, player);
            var hitPlayerAudio = Instantiate(HitPlayerAudio);
            Destroy(hitPlayerAudio, 1);
            return;
        }
        else if (OwnedByPlayer && collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            ToastyActive?.Invoke();
            DestroyBullet(0);
            return;
        }
        else if(OwnedByPlayer && collision.gameObject.TryGetComponent(out Obstale obstale))
        {
            Instantiate(HittingTheGround, transform.position, Quaternion.identity);
            var missAudio = Instantiate(MissAudio);
            Destroy(missAudio, 1);
            DestroyBullet(0);
            return;
        }
        else
        {
            DestroyBullet(0);
        }
    }
}