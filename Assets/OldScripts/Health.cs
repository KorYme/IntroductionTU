using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public struct Health
{
    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public Health(int maxHealth, int currentHealth)
    {
        Assert.IsTrue(maxHealth > 0);
        Assert.IsTrue(currentHealth >= 0);
        Assert.IsTrue(maxHealth >= currentHealth);

        _currentHealth = currentHealth;
        _maxHealth = maxHealth;
    }
    public Health(int maxHealth) : this(maxHealth, maxHealth)
    {

    }

    public bool IsDead => _currentHealth == 0;

    public void TakeDamage(int amount)
    {
        Assert.IsTrue(amount >= 0);
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, MaxHealth);
    }
    public void Heal(int amount)
    {
        Assert.IsTrue(amount >= 0);
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, MaxHealth);
    }
    public void OneShot()
    {
        _currentHealth = 0;
    }


}
