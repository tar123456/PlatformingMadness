using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void showGameOverScreen()
    {
        gameObject.SetActive(true);
    }
    public void showWinScreen()
    {
        gameObject.SetActive(true);
    }
    public void restartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void gotoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
