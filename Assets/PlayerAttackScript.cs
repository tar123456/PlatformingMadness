using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttackScript : MonoBehaviour
{

    // Start is called before the first frame update
    public float movementSpeed;
    public Transform spawner;
    
    PlayerHealthManager healthManager;
   
    public GameObject projectile;
    Animator animator;
    float delay =0;
    
    bool attacking = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        healthManager = GetComponent<PlayerHealthManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.CurrentHealth > 0)
        {
            
                attacking = InputManager.inputManager.fireInput();

                delay += Time.deltaTime;

                animator.SetBool("attack", attacking);

                if (attacking && delay >= 0.1)
                {

                    Instantiate(projectile, spawner.position, transform.rotation);
                    delay = 0;
                    


                }
                
            
          
        }
        
    }

   
}
