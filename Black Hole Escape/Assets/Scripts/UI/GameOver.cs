using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject freezeUI; // UI Panel containing text and button

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f; // Freeze the game
            if (freezeUI != null)
            {
                freezeUI.SetActive(true); // Show UI panel with text and button
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Unfreeze the game
        if (freezeUI != null)
        {
            freezeUI.SetActive(false);
        }
    }
}
