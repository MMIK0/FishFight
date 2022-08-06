using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PooledBehaviour
{
    Rigidbody2D rb;
    public float fireRate = 1f;
    public float speed = 1f;

    public void POW()
    {
        Vector3 lookDirection = transform.up;
      
        rb.velocity = new Vector2(lookDirection.x, lookDirection.y) * speed;
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    public void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
