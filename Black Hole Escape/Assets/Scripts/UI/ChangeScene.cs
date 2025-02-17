using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToGame()
    {
        SceneManager.LoadScene("Main Level");
    }
    public void RestartGame()
    {
        // Reset time scale in case the game was paused
        Time.timeScale = 1;

        // Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.artstation.com/pencil_nexus");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
