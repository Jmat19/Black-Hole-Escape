using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float growthFactor = 1.2f; // Scale increase factor
    public float moveSpeed = 2.0f;    // Movement speed after collision
    private int collisionCount = 0;
    private bool canMove = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            collisionCount++;
            Destroy(other.gameObject);

            if (collisionCount >= 3)
            {
                canMove = true;
                transform.localScale *= growthFactor;
            }
        }
    }

    void Update()
    {
        if (canMove)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}

