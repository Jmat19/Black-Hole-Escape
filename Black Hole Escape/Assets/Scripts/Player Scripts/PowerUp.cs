using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float sizeReductionFactor = 0.8f; // Factor by which target object size decreases
    public float moveDownwardAmount = 2.0f; // Amount by which target object moves down
    public GameObject shrinkBH; // Reference to the object affected by power-up
    private bool powerUpCollected = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!powerUpCollected && collision.CompareTag("PowerUp") && gameObject.CompareTag("Player"))
        {
            powerUpCollected = true;
            Destroy(collision.gameObject); // Remove the power-up object
        }
    }

    void Update()
    {
        if (powerUpCollected && Input.GetKeyDown(KeyCode.Space))
        {
            ModifyTargetObject();
            powerUpCollected = false; // Reset power-up state after use
        }
    }

    void ModifyTargetObject()
    {
        if (shrinkBH != null)
        {
            BoxCollider2D boxCollider = shrinkBH.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.size *= sizeReductionFactor;
            }
            // Reduce size
            shrinkBH.transform.localScale *= sizeReductionFactor;

            // Move downward
            shrinkBH.transform.position -= new Vector3(0, moveDownwardAmount, 0);
        }
    }
}

