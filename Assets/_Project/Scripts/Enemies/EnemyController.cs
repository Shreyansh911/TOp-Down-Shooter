using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector2 m_targetDir;
    Transform m_target;
    Rigidbody2D m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        if (m_target == null) return;

        m_targetDir = (m_target.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        m_rb.velocity = m_targetDir * moveSpeed;
    }

    private void OnDestroy()
    {
        WaveSpawnManager.Instance.RemoveEnenmy(this);
    }
}
