using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 _direction;
    private bool _timer;
    private float _timeToShoot;

    public UnityAction OnShoot;

    private void Update()
    {
        StartCountdown();
        CountTime();
        StopCountdown();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        _direction = eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _direction = Vector2.zero;
    }

    private void StartCountdown()
    {
        if(Input.GetMouseButtonDown(0))
        _timer = true;
    }
    private void StopCountdown()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _timer = false;
            Debug.Log("TimetoShoot" + _timeToShoot);
            if (_timeToShoot > 0.01 && _timeToShoot < 0.15f)
            {
                OnShoot?.Invoke();
            }

            _timeToShoot = 0;
        }
    }

    private void CountTime()
    {
        Debug.Log("Timer" + _timer);
        if (_timer)
        {
            _timeToShoot += Time.deltaTime;
        }
    }

    public Vector2 GetDirection()
    {
        return _direction;
    }
}
