using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGun : MonoBehaviour, IGun
{
    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float bulletSpeed;

    protected float m_shootTime;
    protected float m_timer;

    public bool CanShoot => m_timer >= m_shootTime;

    protected virtual void Start()
    {
        m_shootTime = 1f / fireRate;
        m_timer = m_shootTime;
    }

    public abstract void Shoot();
}
