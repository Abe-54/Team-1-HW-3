using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public PlayableDirector director;
    public BasicMovement player;

    public void StartGame()
    {
        mainMenu.SetActive(false);
        player.canMove = true;
        director.Play();
    }
}
