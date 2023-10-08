using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryLogic : MonoBehaviour
{
    public Dictionary<string, bool> keys = new Dictionary<string, bool>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddKey(string keyName)
    {
        if (!keys.ContainsKey(keyName))
        {
            keys[keyName] = true;
        }
    }

    // Check if the player has a key
    public bool HasKey(string keyName)
    {
        return keys.ContainsKey(keyName) && keys[keyName];
    }
}
