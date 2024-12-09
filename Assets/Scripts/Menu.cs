using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When loading and unloading scenes
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
    public void SampleScene()
    {
        // Load the next scene after current scene
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Game start!");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Load The next scene after the next scene after current scene
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    public void Quit()
    {
        // Closes the game
        Application.Quit();
    }

}