using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RoomUpdater : MonoBehaviour
{
    private Rigidbody2D myRb2d;

    [SerializeField]
    private CinemachineConfiner2D vCamConfiner;

    public PolygonCollider2D startingConfiner;

    // Start is called before the first frame update
    void Start()
    {
        myRb2d = GetComponent<Rigidbody2D>();
        vCamConfiner.m_BoundingShape2D = startingConfiner;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Confiner"))
        {
            vCamConfiner.m_BoundingShape2D = collision.GetComponent<PolygonCollider2D>();
            // Debug.Log("ENTERED: " + collision.name);
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Confiner"))
        {
            vCamConfiner.m_BoundingShape2D = collision.GetComponent<PolygonCollider2D>();
            // Debug.Log("CURRENTLY IN: " + collision.name);
        }
    }
}
