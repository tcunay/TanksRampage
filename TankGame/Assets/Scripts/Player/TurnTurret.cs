using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTurret : MonoBehaviour
{
    [SerializeField] GameObject _turret;
    [SerializeField] private float _rotateSpeed;

    private Quaternion _rotate;

    private float _angle;

    private void Update()
    {
        Turn(SetRotation());
    }

    private float SetRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            _angle = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            _angle = 1;
        else
            _angle = 0;
        return _angle;
    }

    private void Turn(float angle)
    {
        float scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
        _rotate = Quaternion.AngleAxis(angle * scaledRotateSpeed, Vector3.forward);
       _turret.transform.rotation *= _rotate;
    }
}
