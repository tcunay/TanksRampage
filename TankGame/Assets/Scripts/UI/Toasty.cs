using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toasty : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private string _toasty = "Toasty";

    public void ActiveAnim()
    {
        Debug.Log("Toasty");
        _audioSource.Play();
        _animator.SetTrigger(_toasty);
    }
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
