using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float a = 5f; // Semi-major axis
    public float b = 3f; // Semi-minor axis
    public float speed = 1f; // Orbit speed

    public Transform center;

    private float angle;


    void Update()
    {
        angle += Time.deltaTime * speed;

        float x = center.position.x + a * Mathf.Cos(angle);
        float y = center.position.y + b * Mathf.Sin(angle);

        transform.position = new Vector2(x, y);
    }
}
