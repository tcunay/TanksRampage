using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private TrajectoryRenderer _trajectoryRenderer;
    [SerializeField] private Toasty _toasty;
    [SerializeField] private AudioSource _shootAudio;
    [SerializeField] private TouchHandler _touchHandler;

    [SerializeField] private float _throwForce;
    [SerializeField] private float _delay;

    private Bullet _bullet;
    private Bullet _currentBullet;

    private int _currentBulletNumber;
    private float _currentDelay;
    private bool _isPressed;

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
    private void OnEnable()
    {
        _touchHandler.OnShoot += PressShootButton;
    }

    private void OnDisable()
    {
        _currentBullet.ToastyActive -= _toasty.ActiveAnim;
        _touchHandler.OnShoot -= PressShootButton;
    }

    private void Shoot()
    {
        _currentDelay += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Space) || _isPressed) && _currentDelay >= _delay)
        {
            _isPressed = false;
            _bullet = Instantiate(_currentBullet, _shootPoint.transform.position, Quaternion.identity);
            _bullet.ToastyActive += _toasty.ActiveAnim;
            _bullet.InstallForPlayer();
            _currentDelay = 0;

            Rigidbody bullet = _bullet.GetComponent<Rigidbody>();

            bullet.AddForce(_shootPoint.forward * _throwForce, ForceMode.VelocityChange);
            Destroy(_bullet, 5f);
            _shootAudio.Play();
        }
    }

    private void PressShootButton()
    {
        _isPressed = true;
    }


    private void ChangeBullet(Bullet bullet)
    {
        _currentBullet = bullet;
    }

    public void BuyBullet(Bullet bullet)
    {
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
