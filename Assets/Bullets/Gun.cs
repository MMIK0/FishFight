using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float flySpeed;
    public int damage;
    public int projectileCount;
    public List<GameObject> barrels = new List<GameObject>();
    public int barrelAmount;
    public Bullet bullet;
    public float fireRateTimer;

    public void Awake()
    {
        for(int i = 0; i < barrels.Count; i++)
        {
            if(i < barrelAmount)
            {
                barrels[i].SetActive(true);
            }
        }
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
 
        foreach (GameObject barrel in barrels)
        {
            if (barrel.activeInHierarchy)
            {
                Bullet bull = bullet.GetPooledObject(barrel.transform.position) as Bullet;
                bull.transform.rotation = barrel.transform.rotation;
                bull.POW();
            }
        }
        fireRateTimer = 0;
    }
}
