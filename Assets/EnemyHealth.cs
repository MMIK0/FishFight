using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints =20;
    float currentHp;
    private void OnEnable()
    {
        currentHp = hitPoints;
    }
    private void Ouch()
    {
        currentHp -= 1;
        if (currentHp <= 0)
            gameObject.SetActive(false);
        Debug.Log("ouch");
    }
    private void OnDisable()
    {
        BorderSpawner.Instance.EnemyDead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ouch();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Ouch();
    }
}
