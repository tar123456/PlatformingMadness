using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    Animator animator;
    public float forceAmt;
    Rigidbody2D rigidbody2D;
    bool isGrounded;
    bool isFacingRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D =   GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void Update()
    {
        #region movement
        float movementAxis = InputManager.inputManager.movementInput();

        Vector2 movementForce = new Vector2(movementAxis * speed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = movementForce;
        bool ismoving = movementAxis > 0||movementAxis<0;
        animator.SetBool("isRun",ismoving&&isGrounded);

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

        float jumping = InputManager.inputManager.jumpInput();
        if (isGrounded && jumping>0)
        {
            rigidbody2D.AddForce(Vector3.up * forceAmt, ForceMode2D.Impulse);
            isGrounded = false;
            
           
        }
        animator.SetBool("isJump", !isGrounded);

        #endregion

 


    }

    void flipCharacter()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            isGrounded = true;
        
    }
}
