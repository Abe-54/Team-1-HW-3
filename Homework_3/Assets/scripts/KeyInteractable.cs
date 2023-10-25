using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : MonoBehaviour
{
    public string keyName;
    public List<string> interactText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("KEY NAME: " + keyName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
