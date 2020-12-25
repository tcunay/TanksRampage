using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] protected int damage = 1;
    [SerializeField] protected ParticleSystem explosion;

    protected bool ownedByPlayer = false;
    protected float delay = 5f;

    public bool OwnedByPlayer => ownedByPlayer;

    public void DestroyBullet(float delay)
    {
        Destroy(gameObject, delay);
    }
    public void InstallForPlayer()
    {
        ownedByPlayer = true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (ownedByPlayer && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            DestroyBullet(0);
            return;
        }
        else if (!ownedByPlayer && collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            DestroyBullet(0);
            return;
        }
        else if (ownedByPlayer && collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            DestroyBullet(0);
            return;
        }
        else
        {
            DestroyBullet(0);
        }
    }
}
