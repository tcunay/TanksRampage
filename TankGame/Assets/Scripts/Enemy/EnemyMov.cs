using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class EnemyMov : MonoBehaviour
{
    [SerializeField] private int _waypointsSize = 5;
    [SerializeField] private int _moveSpeed;
    [SerializeField] private int _rotateSpeed;

    private Vector3[] _waypoints;

    private void Start()
    {
        _waypoints = new Vector3[_waypointsSize];

        for (int i = 0; i < _waypointsSize; i++)
        {
            _waypoints[i] = new Vector3(Random.Range(-22f, 22f), transform.position.y, Random.Range(3f, 33f));
        }
        Tween tween = transform.DOPath(_waypoints, 15, PathType.CatmullRom)
            .SetOptions(true).SetLookAt(0.05f, new Vector3(-1, 0, 0), new Vector3(0, 0, -1));
        tween.SetEase(Ease.Linear).SetLoops(-1);
    }
}

