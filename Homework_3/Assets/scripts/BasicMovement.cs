using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to set the movement speed

    public float horizontalInput = 0;
    public float verticalInput = 0;

    public Vector3 movement;
    
    //2d rigidbody
    public Rigidbody2D myRigidbody2d;

    public bool canMove = false;
    public GameObject playerLight;

    void Update()
    {

        horizontalInput = 0;
        verticalInput = 0;
    
        if (Input.GetKey("left"))
        {
            horizontalInput -= 1;
        }
        if (Input.GetKey("right"))
        {
            horizontalInput += 1;
        }


        if (Input.GetKey("up"))
        {
            verticalInput += 1;
        }
        if (Input.GetKey("down"))
        {
            verticalInput -= 1;
        }

        if (canMove)
        {
            movement.x = horizontalInput * moveSpeed;
            movement.y = verticalInput * moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        myRigidbody2d.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }

    public void SetCanMove()
    {
        canMove = true;
    }

    public void TurnOnPlayerLight()
    {
        playerLight.SetActive(true);
    }
}
