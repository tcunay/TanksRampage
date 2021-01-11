using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxXPosition;
    [SerializeField] private float _minZPosition;
    [SerializeField] private float _maxZPosition;

    [SerializeField] private int _waypointsSize;
    [SerializeField] private int _duration;

    private Vector3[] _waypoints;

    private void Start()
    {
        Spawner spawner = new Spawner();
        _waypoints = new Vector3[_waypointsSize];

        for (int i = 0; i < _waypointsSize; i++)
        {
            _waypoints[i] = new Vector3(Random.Range(_minXPosition, _maxXPosition), transform.position.y,
                Random.Range(_minZPosition, _maxZPosition));
        }
        Tween tween = transform.DOPath(_waypoints, _duration, PathType.CatmullRom)
            .SetOptions(true).SetLookAt(0.01f, new Vector3(0, 0, -1));
        tween.SetEase(Ease.Linear).SetLoops(-1);
    }

}

