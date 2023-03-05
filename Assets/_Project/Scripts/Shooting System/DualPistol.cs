using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPistol : BaseGun
{
    [SerializeField] Transform leftShootPoint;
    [SerializeField] Transform rightShootPoint;

    private void Update()
    {
        if(CanShoot && Input.GetMouseButtonDown(0))
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
        Bullet bullet1 = Instantiate(bulletPrefab, leftShootPoint.position, Quaternion.identity);
        Bullet bullet2 = Instantiate(bulletPrefab, rightShootPoint.position, Quaternion.identity);

        bullet1.Launch(leftShootPoint.up * bulletSpeed);
        bullet2.Launch(rightShootPoint.up * bulletSpeed);
    }
}
