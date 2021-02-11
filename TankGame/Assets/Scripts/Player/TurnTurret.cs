using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTurret : MonoBehaviour
{
    [SerializeField] private GameObject _turret;
    [SerializeField] private TouchHandler _touchHandler;
    [SerializeField] private float _rotateSpeed;

    private Quaternion _rotate;

    private void Update()
    {
        Turn(_touchHandler.GetDirection());
    }

    private void Turn(Vector2 angle)
    {
        float scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
        _rotate = Quaternion.AngleAxis(angle.x * scaledRotateSpeed, Vector3.forward);
       _turret.transform.rotation *= _rotate;
    }
}
