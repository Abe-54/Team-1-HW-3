using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InteractableObject : MonoBehaviour
{
    [TextArea(3, 10)]
    public List<string> interactText;
}
