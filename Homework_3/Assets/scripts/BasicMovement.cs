using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to set the movement speed

    public float horizontalInput = 0;
    public float verticalInput = 0;

    public Vector3 movement;

    //2d rigidbody
    public Rigidbody2D myRigidbody2d;

    public bool canMove = false;


    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        myRigidbody2d.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }

    public void SetCanMove()
    {
        canMove = true;
        Debug.Log("PLAYER CAN NOW MOVE!");
    }
}
