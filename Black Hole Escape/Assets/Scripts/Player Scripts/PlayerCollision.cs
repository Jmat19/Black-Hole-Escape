using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform targetObject; // The object that will grow

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            GrowthModifier modifier = other.GetComponent<GrowthModifier>();
            if (modifier != null)
            {
                targetObject.localScale += Vector3.one * modifier.growthAmount;
            }
        }
    }
}

public class GrowthModifier : MonoBehaviour
{
    public float growthAmount = 50.0f; // Changeable growth amount per object
}


