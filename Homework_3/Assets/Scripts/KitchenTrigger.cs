using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTrigger : MonoBehaviour
{
    public GameObject newKitchenDoor;

    private void Start()
    {

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
        }
    }
}
