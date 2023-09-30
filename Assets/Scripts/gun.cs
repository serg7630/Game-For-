using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float speedBullet = 20f;

    public int DamageGun=1;

    private bool rechargeGun=true;

    public float rechargeTime;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")&&rechargeGun)
        {

            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet=Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb_2d=bullet.GetComponent<Rigidbody2D>();
        rb_2d.AddForce(firePoint.up*speedBullet,ForceMode2D.Impulse);

        bullet.GetComponent<Bullet>().DamageBullet=DamageGun;

        rechargeGun = false;
        Invoke("rechargeGunTime", rechargeTime);
    }

    private void rechargeGunTime()
    {
        rechargeGun = true;
    }
}