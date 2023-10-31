using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float health = 100;
    public float speed = 5f;

    private float initialHealth;

    public BasicMovement player;

    private SpriteRenderer ghostSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicMovement>();
        ghostSpriteRenderer = GetComponent<SpriteRenderer>();
        initialHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //Ghost moves towards player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        //Ghost dies when health reaches 0
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        float opacity = health / initialHealth;
        ghostSpriteRenderer.color = new Color(ghostSpriteRenderer.color.r, ghostSpriteRenderer.color.g, ghostSpriteRenderer.color.b, opacity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ghost dies when it collides with player
        if (other.gameObject.tag == "Player")
        {
            //Fade to black then respawn the player outside the room
            // StartCoroutine(player.Respawn());
        }
    }
}
