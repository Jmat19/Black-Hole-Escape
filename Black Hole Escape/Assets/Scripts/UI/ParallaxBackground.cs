using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the scrolling background
    public float resetHeight;  // The height at which the background resets

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        if (resetHeight == 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            resetHeight = spriteRenderer.bounds.size.y;
        }
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= startPosition.y - resetHeight)
        {
            transform.position = startPosition;
        }
    }
}

