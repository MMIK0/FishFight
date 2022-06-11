using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemyMoveSpeed;
    public int enemyDamage;
    public Vector3 target;
    public enemyType typeOfEnemy;

    public enum enemyType
    {
        red,
        blue,
        white
    }

    void FixedUpdate()
    {
        if (Player.instance != null)
        {
            transform.position = Player.instance.transform.position;
            transform.rotation = Quaternion.Euler(Player.instance.transform.position.x, Player.instance.transform.position.y, Player.instance.transform.position.x);
            target = Player.instance.transform.position;
            transform.RotateAround(target, Vector3.back, 20 * Time.deltaTime);
        }
    }

}
