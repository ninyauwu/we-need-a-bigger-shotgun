using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth;
    private float _currentHealth;
    public float CurrentHealth { get { return _currentHealth; } }

    private void Start()
    {
        if (TryGetComponent(out PlayerController player))
        {
            _maxHealth = player.Stats.Health;
        }
        // TODO: Add a way to get the max health from the Enemy
        
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
