using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer _lineRendererComponent;
    private Vector3[] _points;

    private float _elapsedTime;

    private void Start()
    {
        _lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        _points = new Vector3[100];
        _lineRendererComponent.positionCount = _points.Length;
        for (int i = 0; i < _points.Length; i++)
        {
            _elapsedTime = i * 0.1f;

            _points[i] = origin + speed * _elapsedTime + Physics.gravity * _elapsedTime * _elapsedTime / 2f;

            if(_points[i].y < -5)
            {
                _lineRendererComponent.positionCount = i + 5;
                break;
            }
        }
        _lineRendererComponent.SetPositions(_points);
    }
}
