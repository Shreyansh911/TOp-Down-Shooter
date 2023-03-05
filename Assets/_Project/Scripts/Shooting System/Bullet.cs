using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] float DeathTime;
    [SerializeField] int bulletDamage;

    Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector3 force)
    {
        m_rb.velocity = force;
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(DeathTime);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IHealth health = other.gameObject.GetComponent<IHealth>();
        if(health != null)
        {
            health.TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}
