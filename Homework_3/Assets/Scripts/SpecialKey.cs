using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialKey : MonoBehaviour
{
    private UiController ui;
    private PlayerInventoryLogic inventory;
    private SpriteRenderer spriteRenderer;
    public string keyName;
    public GameObject enemyToKill;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<PlayerInventoryLogic>();
        ui = FindObjectOfType<UiController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.AddKey(keyName);
            ui.item.sprite = spriteRenderer.sprite;
            ui.item.gameObject.SetActive(true);
            enemyToKill.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
