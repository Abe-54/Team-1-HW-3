using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorInteractable : MonoBehaviour
{
    public string keyName;
    public List<string> hasKeyText;
    public List<string> interactText;
    public PlayableDirector cutsceneDirector;

    public AudioSource doorOpening;
}
