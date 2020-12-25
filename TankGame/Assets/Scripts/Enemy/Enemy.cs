using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private KillCounter _killCounter;

    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _reward = 100;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> EnemyDied;

    public int Damage => _damage;
    public int Reward => _reward;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        EnemyDied?.Invoke(_reward);
        this.EnemyDied -= _killCounter.OnKillsChanged;
        Destroy(gameObject);
    }
}
