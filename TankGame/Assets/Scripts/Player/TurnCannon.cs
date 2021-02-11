using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TurnCannon : MonoBehaviour
{
    [SerializeField] private GameObject _cannon;
    [SerializeField] private TouchHandler _touchHandler;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        Turn(_touchHandler.GetDirection());
    }

    private void Turn(Vector2 angle)
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
        _cannon.transform.Rotate(-angle.y * scaledRotateSpeed, 0, 0);
    }
}
