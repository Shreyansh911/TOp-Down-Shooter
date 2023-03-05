using UnityEngine;

public class Pistol : BaseGun
{
    [SerializeField] Transform shootPoint;
   

    void Update()
    {

        if(CanShoot &&  Input.GetMouseButtonDown(0))
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
        m_timer = 0f;
        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.Launch(shootPoint.up * bulletSpeed);
    }
}
