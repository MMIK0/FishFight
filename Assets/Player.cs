using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float speed;
    Vector2 movement;
    public Rigidbody2D playerRB;

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
    }
}
