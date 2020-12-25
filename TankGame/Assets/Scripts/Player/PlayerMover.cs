using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Vector2 _direction;
    private Quaternion _rotate;

    private float _angle;

    private void Update()
    {
        Move(SetDirection());
        Turn(SetRotation());
    }

    private Vector2 SetDirection()
    {
        if (Input.GetKey(KeyCode.W))
            _direction = new Vector2(0, 2);
        else if (Input.GetKey(KeyCode.S))
            _direction = new Vector2(0, -2);
        else
            _direction = new Vector2(0, 0);
        return _direction;
    }

    private void Move(Vector2 direction)
    {
        float scaleRotateSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(0, 0, direction.y);
        transform.position += move * scaleRotateSpeed;
    }
    private float SetRotation()
    {
        if (Input.GetKey(KeyCode.A))
            _angle = -1;
        else if (Input.GetKey(KeyCode.D))
            _angle = 1;
        else
            _angle = 0;
        return _angle;
    }
    private void Turn(float angle)
    {
        float scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
        _rotate = Quaternion.AngleAxis(angle * scaledRotateSpeed, Vector3.forward);
        transform.rotation *= _rotate;
    }
}
