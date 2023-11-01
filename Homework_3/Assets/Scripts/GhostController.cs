using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float health = 100;
    public float speed = 5f;
    public bool shouldDropKey;
    public GameObject keyPrefab;

    private float initialHealth;

    public BasicMovement playerMovement;
    public FlashlightController player;
    public BossRoomLogic bossRoomLogic;

    private SpriteRenderer ghostSpriteRenderer;

    private void Start()
    {
        player = FindObjectOfType<FlashlightController>();
        playerMovement = FindObjectOfType<BasicMovement>();
        ghostSpriteRenderer = GetComponent<SpriteRenderer>();
        bossRoomLogic = FindObjectOfType<BossRoomLogic>();
        initialHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasFlashlight)
        {
            Vector2 currentPosition = transform.position;

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 originalLocalScale = transform.localScale;


            if (currentPosition.x < player.transform.position.x)
            {
                //flip the ghost game object to face the player
                transform.localScale = new Vector3(-Mathf.Abs(originalLocalScale.x), originalLocalScale.y, originalLocalScale.z);
            }
            else if (currentPosition.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(Mathf.Abs(originalLocalScale.x), originalLocalScale.y, originalLocalScale.z);
            }
        }


        //Ghost dies when health reaches 0
        if (health <= 0)
        {
            bossRoomLogic.IncreaseGhostsKilled();

            if (shouldDropKey)  // Add this condition
            {
                Instantiate(keyPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        float opacity = health / initialHealth;
        ghostSpriteRenderer.color = new Color(ghostSpriteRenderer.color.r, ghostSpriteRenderer.color.g, ghostSpriteRenderer.color.b, opacity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ghost dies when it collides with player
        if (other.gameObject.tag == "Player" && !playerMovement.isRespawning)
        {
            playerMovement.KillPlayer();
        }
    }
}
