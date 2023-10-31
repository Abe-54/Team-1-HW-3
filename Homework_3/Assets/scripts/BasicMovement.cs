using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BasicMovement : MonoBehaviour
{
    public Transform spawnPoint;

    public Image fadeImage;

    public float moveSpeed = 5f; // Adjust this to set the movement speed

    public float horizontalInput = 0;
    public float verticalInput = 0;

    public Vector3 movement;

    public Rigidbody2D myRigidbody2d;

    public bool canMove = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);

        animator.SetFloat("Magnitude", myRigidbody2d.velocity.magnitude);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        myRigidbody2d.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Player has reached the end of the level!");
            canMove = false;
            myRigidbody2d.velocity = Vector2.zero;
        }
    }

    public IEnumerator Respawn()
    {
        canMove = false;
        myRigidbody2d.velocity = Vector2.zero;
        fadeImage.gameObject.SetActive(true);
        fadeImage.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1f);
        transform.position = spawnPoint.position;
    }
}
