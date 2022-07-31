using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ScoreView()
    {
        Debug.Log("Score Table Loaded!");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quited!"); //DELETE BEFORE RELEASE
        Application.Quit();
    }
}
