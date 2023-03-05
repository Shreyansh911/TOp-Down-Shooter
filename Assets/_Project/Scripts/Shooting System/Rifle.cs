using UnityEngine;

public class Rifle : BaseGun
{
    [SerializeField] Transform shootPoint;

    private void Update()
    {
        if (CanShoot && Input.GetMouseButton(0))
        {
            Shoot();
        }
        else
        {
            m_timer += Time.deltaTime;
        }
    }

    public override void Shoot()
    {
        m_timer = 0;
        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.Launch(shootPoint.up * bulletSpeed);
    }
}
