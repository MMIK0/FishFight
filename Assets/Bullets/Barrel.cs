using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float flySpeed;
    public int damage;
    public int projectileCount;
    public int barrelAmount;
    public Bullet bullet;
    public float fireRateTimer;
    public int id;

    public void Awake()
    {
    }

    public void Update()
    {
        fireRateTimer += Time.deltaTime;
        Shoot();
    }

    public void Shoot()
    {
        if(fireRateTimer <= bullet.fireRate)
            return;
 
        Bullet bull = bullet.GetPooledObject(transform.position) as Bullet;
        bull.transform.rotation = transform.rotation;
        bull.POW();

        fireRateTimer = 0;
    }
}
