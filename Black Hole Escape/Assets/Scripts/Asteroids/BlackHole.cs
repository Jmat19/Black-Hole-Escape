using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float sizeGrowthFactor = 1.5f; // Factor by which BoxCollider and Sprite size increases
    public float moveUpwardAmount = 2.0f; // Amount by which the Black Hole moves up
    public GameObject blackHole; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player") && collision.CompareTag("Asteroid"))
        {
            IncreaseSizeAndMove();
        }
    }

    void IncreaseSizeAndMove()
    {
        if (blackHole != null)
        {
            // Increase BoxCollider size
            BoxCollider2D boxCollider = blackHole.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.size *= sizeGrowthFactor;
            }

            // Increase Sprite size
            blackHole.transform.localScale *= sizeGrowthFactor;

            // Move objectC upward
            blackHole.transform.position += new Vector3(0, moveUpwardAmount, 0);
        }
    }
}


