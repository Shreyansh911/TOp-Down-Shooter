using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour, IHealth
{
    [SerializeField] int maxHealth;
    [Header("VFX")]
    [SerializeField] ParticleSystem deathEffect;

    int m_currentHealth;

    private void Start()
    {
        m_currentHealth = maxHealth;
    }

    public int CurrentHelth => m_currentHealth;

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    public void TakeDamage(int Damage)
    {
        m_currentHealth -= Damage * 2;
        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            Die();
        }
    }
}
