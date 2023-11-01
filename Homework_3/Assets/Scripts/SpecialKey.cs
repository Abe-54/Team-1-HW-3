using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialKey : MonoBehaviour
{
    private UiController ui;
    private PlayerInventoryLogic inventory;
    private SpriteRenderer spriteRenderer;
    private FlashlightController flashlight;
    public string keyName;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<PlayerInventoryLogic>();
        ui = FindObjectOfType<UiController>();
        flashlight = FindObjectOfType<FlashlightController>();
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
            ui.UpdateInventoryUI(spriteRenderer.sprite, new Vector3(0, 0, 90));
            ui.item.gameObject.SetActive(true);
            gameObject.SetActive(false);
            flashlight.hasFlashlight = false;
        }
    }
}
