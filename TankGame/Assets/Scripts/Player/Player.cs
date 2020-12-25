using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _money = 0;

    private int _currentHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction PlayerDied;

    private void Awake()
    {
        this.PlayerDied += _menu.GameOver;
    }

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }
    public void Die()
    {
        PlayerDied?.Invoke();
        this.PlayerDied -= _menu.GameOver;
        Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        _money += money;
        Debug.Log("Money = " + _money);
        //MoneyChanged?.Invoke(_money);
    }

}
