using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float speed;
    Vector2 movement;
    public Rigidbody2D playerRB;
    public Transform rotatingDiscL, rotatingDiscR;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }
    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * speed * Time.fixedDeltaTime);
        Vector3 mousPos = transform.position - Input.mousePosition;
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, 0);
        //Vector2 dir = new Vector2(playerPos.x - mousPos.x, playerPos.z - mousPos.z); 
        //float angle = Vector2.SignedAngle(Vector2.up, dir); 
        //transform.rotation = Quaternion.Euler(-90, 0, 360 - angle);
    }
}
