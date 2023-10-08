using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTeddyBear : MonoBehaviour
{
    public GameObject teddyBear;
    public GameObject newPos;

    public bool isTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            Debug.Log("Teddy Bear Triggered");
            teddyBear.transform.position = newPos.transform.position;
            teddyBear.SetActive(true);
            isTriggered = true;
        }
    }
}
