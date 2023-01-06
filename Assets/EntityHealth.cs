using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;

    private int _currentHealth;

    public int CurrentHealth 
    {
        get => _currentHealth;
        private set => _currentHealth = value;
    }

    public bool IsDead
    {
        get => CurrentHealth <= 0;
    }

    [SerializeField] UnityEvent _onDamageTaken;
    [SerializeField] UnityEvent _onHeal;
    [SerializeField] UnityEvent _onDeath;

    private void Awake()
    {
        Assert.IsTrue(_maxHealth > 0);
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (IsDead) return;
        CurrentHealth -= Math.Clamp(damageAmount, 0, CurrentHealth);
        _onDamageTaken?.Invoke();
        if (IsDead)
        {
            _onDeath?.Invoke();
        }
    }

    public void Heal(int healAmount)
    {
        if (IsDead) return;
        CurrentHealth += Math.Clamp(healAmount, 0, _maxHealth - CurrentHealth);
        _onHeal?.Invoke();
    }
}
