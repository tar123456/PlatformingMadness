using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    public static InputManager inputManager { get; private set; }



    public void Awake()
    {
        if (inputManager != null && inputManager != this)
        {
            Destroy(this);
        }
        else
        { 
            inputManager = this;
        }
    }

    

    public float movementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        return horizontalInput;
    }

    public float jumpInput()
    {
        float jumpPressed = Input.GetAxis("Jump");

        return jumpPressed;
    }

    public bool fireInput()
    {
        bool firePressed = Input.GetButtonDown("Fire");
        return firePressed;
      
    }

    public bool pauseResume()
    {
        bool pausePressed = Input.GetButton("Cancel");
        Debug.Log("input pressed " + pausePressed);
        

      return pausePressed;
        
    }    

}
