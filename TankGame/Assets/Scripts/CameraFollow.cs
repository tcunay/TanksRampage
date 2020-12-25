using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_player != null)
        _camera.transform.position = new Vector3(_player.transform.position.x, _camera.transform.position.y, _camera.transform.position.z);
    }
}
