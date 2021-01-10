using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class EnemyMov : MonoBehaviour
{
    [SerializeField] private int _waypointsSize = 1;
    [SerializeField] private int _moveSpeed;
    [SerializeField] private int _rotateSpeed;


    private Vector3[] _waypoints;
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;
    private void Start()
    {
        _previousPosition = transform.position;
        
        _waypoints = new Vector3[_waypointsSize];

        for (int i = 0; i < _waypointsSize; i++)
        {
            _waypoints[i] = new Vector3(Random.Range(-22f, 22f), transform.position.y, Random.Range(3f, 33f));
        }
        Tween tween = transform.DOPath(_waypoints, 15, PathType.CatmullRom)
            .SetOptions(true).SetLookAt(0.01f, new Vector3(0, 0, -1));
        tween.SetEase(Ease.Linear).SetLoops(-1);
    }
    //private void FixedUpdate()
    //{
    //    _currentPosition = transform.position;
    //    Vector3 direction = (_previousPosition - _currentPosition);
    //    transform.localRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
    //    _previousPosition = _currentPosition;

        
    //}
}

