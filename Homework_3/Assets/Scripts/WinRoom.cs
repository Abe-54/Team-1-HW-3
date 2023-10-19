using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WinRoom : MonoBehaviour
{
    public BasicMovement playerMovement;
    public PlayableDirector finishCutscene;

    private void Awake()
    {
        playerMovement = FindObjectOfType<BasicMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You win!");
            playerMovement.enabled = false;
            finishCutscene.Play();
        }
    }
}
