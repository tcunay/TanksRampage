using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _health;

    
    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        _health.text = value.ToString();
    }
}
