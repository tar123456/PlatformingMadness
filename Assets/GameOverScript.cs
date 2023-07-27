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
    public void restartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
