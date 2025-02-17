using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas gameCanvas; // Assign the Canvas GameObject in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Ensure Player has the "Player" tag
        {
            // Pause the game
            Time.timeScale = 0;

            // Change the Canvas Order in Layer
            ChangeCanvasOrder(gameCanvas, 1);
        }
    }

    void ChangeCanvasOrder(Canvas canvas, int order)
    {
        if (canvas != null)
        {
            canvas.sortingOrder = order; // Update sorting order
        }
        else
        {
            Debug.LogError("Canvas is not assigned!");
        }
    }
}
