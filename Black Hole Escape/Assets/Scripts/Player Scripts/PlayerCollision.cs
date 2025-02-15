using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public string objectTag1 = "Asteroid";
    public string objectTag2 = "PowerUp";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object matches one of the specified tags
        if (other.CompareTag(objectTag1) || other.CompareTag(objectTag2))
        {
            // Destroy the colliding object
            Destroy(other.gameObject);
        }
    }
}


