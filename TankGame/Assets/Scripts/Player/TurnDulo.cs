using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TurnDulo : MonoBehaviour
{
    [SerializeField] private GameObject _dulo;
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
        if (_dulo.transform.localRotation.x > 0.1f)
        {
            _dulo.transform.localRotation =
                new Quaternion
                (_dulo.transform.localRotation.x - 0.01f,
                _dulo.transform.localRotation.y,
                _dulo.transform.localRotation.z,
                _dulo.transform.localRotation.w);
        }
        else if (_dulo.transform.localRotation.x < -0.3)
        {
            _dulo.transform.localRotation =
                new Quaternion
                (_dulo.transform.localRotation.x + 0.01f,
                _dulo.transform.localRotation.y,
                _dulo.transform.localRotation.z,
                _dulo.transform.localRotation.w);
        }
        _dulo.transform.Rotate(angle * scaledRotateSpeed, 0, 0);
    }
}
