using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TurnCannon : MonoBehaviour
{
    [SerializeField] private GameObject _cannon;
    [SerializeField] private float _rotateSpeed;

    private float _angle = 0;

    private void Update()
    {
        Turn(SetRotationDulo());
    }

    public float SetRotationDulo()
    {
            if (Input.GetKey(KeyCode.DownArrow))
                _angle = 1;
            else if (Input.GetKey(KeyCode.UpArrow))
                _angle = -1;
            else
                _angle = 0;
            return _angle;
    }

    private void Turn(float angle)
    {
        float scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
        if (_cannon.transform.localRotation.x > 0.1f)
        {
            _cannon.transform.localRotation =
                new Quaternion
                (_cannon.transform.localRotation.x - 0.01f,
                _cannon.transform.localRotation.y,
                _cannon.transform.localRotation.z,
                _cannon.transform.localRotation.w);
        }
        else if (_cannon.transform.localRotation.x < -0.3)
        {
            _cannon.transform.localRotation =
                new Quaternion
                (_cannon.transform.localRotation.x + 0.01f,
                _cannon.transform.localRotation.y,
                _cannon.transform.localRotation.z,
                _cannon.transform.localRotation.w);
        }
        _cannon.transform.Rotate(angle * scaledRotateSpeed, 0, 0);
    }
}
