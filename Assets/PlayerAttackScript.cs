using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttackScript : MonoBehaviour
{

    // Start is called before the first frame update
    public float movementSpeed;
    public Transform spawner;

   
    public GameObject projectile;
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool attacking = InputManager.inputManager.fireInput();
        
       
        if (attacking)
        {

           Instantiate(projectile, spawner.position,transform.rotation);
            
            
  
        }
        animator.SetBool("attack",attacking);
        
    }

   
}
