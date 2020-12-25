using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Bullet _currentBullet;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _throwForce;
    [SerializeField] private float _delay = 5;

    private float _currentDelay;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        _currentDelay += Time.deltaTime;

        if (_currentDelay >= _delay)
        {
            var _bullet = Instantiate(_currentBullet, _shootPoint.transform.position, Quaternion.identity);

            Rigidbody bullet = _bullet.GetComponent<Rigidbody>();

            bullet.AddForce(_shootPoint.forward * _throwForce, ForceMode.VelocityChange);
            _currentDelay = Random.Range(0f, 0.5f);
        }
    }
}
