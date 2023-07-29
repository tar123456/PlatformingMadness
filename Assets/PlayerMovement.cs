using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    Animator animator;
    public float forceAmt;
    Rigidbody2D rigidbody2D;
    bool isGrounded;
    bool isFacingRight = true;
    PlayerHealthManager healthManager;
    bool paused;
   

    void Start()
    {
        animator = GetComponent<Animator>();
        
        isGrounded = true;
        healthManager = GetComponent<PlayerHealthManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        paused = false;
       
     
    }
   
    void Update()
    {
        paused = InputManager.inputManager.pauseResume();
        
        
            if (healthManager.CurrentHealth > 0)
            {
                #region movement
                float movementAxis = InputManager.inputManager.movementInput();

                Vector2 movementForce = new Vector2(movementAxis * speed, rigidbody2D.velocity.y);
                rigidbody2D.velocity = movementForce;
                bool ismoving = movementAxis > 0 || movementAxis < 0;
                animator.SetBool("isRun", ismoving && isGrounded);

                if (movementAxis < 0 && isFacingRight)
                {
                    flipCharacter();
                }
                else if (movementAxis > 0 && !isFacingRight)
                {
                    flipCharacter();
                }



            #endregion

                #region jump

            if (Time.timeScale > 0)
            {
                float jumping = InputManager.inputManager.jumpInput();
               
                if (isGrounded && jumping > 0)
                {
                    rigidbody2D.AddForce(Vector3.up * forceAmt, ForceMode2D.Impulse);
                    isGrounded = false;
                    FindObjectOfType<AudioManager>().play("Jump");
                    

                }
                animator.SetBool("isJump", !isGrounded);
              
            }
                #endregion

            }
        
        


    }

    void flipCharacter()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
        
    }
}
