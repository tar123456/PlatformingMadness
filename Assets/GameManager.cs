using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool paused;
    public GameObject pauseObject;
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        paused = InputManager.inputManager.pauseResume();
        #region pause
        if (paused)
        {
            pauseObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseObject.SetActive(false);
            Time.timeScale = 1;
        }



        #endregion
    }

  

}
