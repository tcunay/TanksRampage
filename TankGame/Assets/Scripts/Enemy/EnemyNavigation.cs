using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private GameObject _dulo;
    [SerializeField] private GameObject _turret;
    [SerializeField] private Player _target;

    private void Update()
    {
        RotateTurret();
    }

    private void RotateTurret()
    {
        Vector3 lookDirection = _target.transform.position - _turret.transform.position;
        lookDirection = new Vector3(lookDirection.y, -lookDirection.z, 0);
        _turret.transform.rotation = Quaternion.LookRotation(lookDirection, new Vector3(0,0,1));
    }
}
