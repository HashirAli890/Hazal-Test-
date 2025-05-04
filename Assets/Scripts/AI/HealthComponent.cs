using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100;
    public UnityEvent OnDeath;

    private float currentHealth;

    private void Awake() => currentHealth = maxHealth;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
            gameObject.SetActive(false); // or use pooling
        }
    }
}

