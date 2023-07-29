using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonScript : MonoBehaviour
{
    public GameOverScript gameOverScript;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            gameOverScript.showWinScreen();
        }
    }
}
