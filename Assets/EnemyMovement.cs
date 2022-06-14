using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemyMoveSpeed,distanceToKeepFromPlayer=1f;
    public int enemyDamage;
    public MovementOnArrival movementOnArrival = MovementOnArrival.none;
    public bool ReverseArrivalMovementDir;
    private Vector3 fixedrotationLocalPos= Vector3.zero;


    void FixedUpdate()
    {

        if (Player.instance != null)
        {
            if (HasReachedTargetDistance())
            {
                if (movementOnArrival == MovementOnArrival.chasingCirlce)
                    ChasingCircle();
                else if (movementOnArrival == MovementOnArrival.fixedCircle)
                    FixedCircle();

            }
            else
                Beeline();                        
        }
    }

    public bool HasReachedTargetDistance()
    {
        if (Vector2.SqrMagnitude(transform.position - Player.instance.transform.position) > distanceToKeepFromPlayer * distanceToKeepFromPlayer)
            return false;
        else
            return true;
    }

    public void Beeline()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.instance.transform.position, enemyMoveSpeed * Time.fixedDeltaTime);
    }

    void ChasingCircle()
    {
        Vector3 vec = Vector3.Cross(transform.position - Player.instance.transform.position, Vector3.forward);
        if (ReverseArrivalMovementDir)
            vec = -vec;
        transform.position = Vector2.MoveTowards(transform.position, transform.position + vec, enemyMoveSpeed * Time.fixedDeltaTime);
    }
    void FixedCircle()
    {
        
        if (ReverseArrivalMovementDir)
            transform.SetParent(Player.instance.rotatingDiscL);
        else
            transform.SetParent(Player.instance.rotatingDiscR);
        if (fixedrotationLocalPos == Vector3.zero)
            fixedrotationLocalPos = transform.localPosition;
        else
            transform.localPosition = fixedrotationLocalPos;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public enum MovementOnArrival
    {
        none,
        fixedCircle,
        chasingCirlce,

    }
}
