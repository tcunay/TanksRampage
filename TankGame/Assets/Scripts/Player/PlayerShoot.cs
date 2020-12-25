using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private TrajectoryRenderer _trajectoryRenderer;

    [SerializeField] private float _throwForce;
    [SerializeField] private float _delay;

    private Bullet _bullet;
    private Bullet _currentBullet;

    private int _currentBulletNumber = 0;
    private float _currentDelay;

    private void Start()
    {
        ChangeBullet(_bullets[_currentBulletNumber]);
        _currentDelay = _delay;
    }

    private void Update()
    {
        ShowTrajectory();
        Shoot();
        
    }
    

    private void Shoot()
    {
        _currentDelay += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && _currentDelay >= _delay)
        {
            _bullet = Instantiate(_currentBullet, _shootPoint.transform.position, Quaternion.identity);
            _bullet.InstallForPlayer();
            _currentDelay = 0;

            Rigidbody bullet = _bullet.GetComponent<Rigidbody>();

            bullet.AddForce(_shootPoint.forward * _throwForce, ForceMode.VelocityChange);
            Destroy(_bullet, 5f);
        }
    }

    private void ChangeBullet(Bullet bullet)
    {
        _currentBullet = bullet;
    }

    public void BuyBullet(Bullet bullet)
    {
        //Money -= bullet.Price;
        //MoneyChanged?.Invoke(Money);
        _bullets.Add(bullet);
    }

    public void PreviosBullet()
    {
        if (_currentBulletNumber == 0)
            _currentBulletNumber = _bullets.Count - 1;
        else
            _currentBulletNumber--;
        ChangeBullet(_bullets[_currentBulletNumber]);
    }

    public void NextBullet()
    {
        if (_currentBulletNumber == _bullets.Count - 1)
            _currentBulletNumber = 0;
        else
            _currentBulletNumber++;
        ChangeBullet(_bullets[_currentBulletNumber]);
    }

    private void ShowTrajectory()
    {
        _trajectoryRenderer.ShowTrajectory(_shootPoint.transform.position, _shootPoint.forward * _throwForce);
    }

}
