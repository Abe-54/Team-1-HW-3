using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightLogic : MonoBehaviour
{
    public float damagePerSecond = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            other.gameObject.GetComponent<GhostController>().health -= damagePerSecond * Time.deltaTime;
        }
    }
}
