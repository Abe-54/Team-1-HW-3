using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTrigger : MonoBehaviour
{
    public GameObject newKitchenDoor;

    private BossRoomLogic bossRoomLogic;

    private void Start()
    {
        bossRoomLogic = FindObjectOfType<BossRoomLogic>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered kitchen, start waves");
            newKitchenDoor.SetActive(true);
            bossRoomLogic.SpawnWave();
            gameObject.SetActive(false);
        }
    }
}
