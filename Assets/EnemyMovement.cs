using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemyMoveSpeed;
    public int enemyDamage;

    void FixedUpdate()
    {
        if (Player.instance != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.transform.position, enemyMoveSpeed * Time.fixedDeltaTime);
        }
    }
}
