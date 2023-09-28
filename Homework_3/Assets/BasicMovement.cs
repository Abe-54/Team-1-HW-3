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

    //3d rigidbody
    public Rigidbody myRigidbody;
    
    //2d rigidbody
    public Rigidbody2D myRigidbody2d;


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

        movement.x = horizontalInput * moveSpeed;
        movement.y = verticalInput * moveSpeed;

        // Move the GameObject
        // transform.Translate(movement * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        myRigidbody2d.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }


    public void PulseMovement() 
    {
        myRigidbody.AddForce(new Vector3(1, 1), ForceMode.Force);

        myRigidbody.velocity = new Vector3(1, 1);
    
    }

    public void OnCollisionEnter(Collision collision)
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        
    }

}
