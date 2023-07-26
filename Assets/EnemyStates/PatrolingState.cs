using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PatrolingState : IBaseState
{
    Vector3 PatrolPosition1;
    Vector3 PatrolPosition2;
    bool movingToPosition1 = false;
    Vector3 CurrentPosition;
    bool characterFlipped;
  
    public void enter(EnemyScript enemyScript, Animator animator)
    {
        animator.SetBool("Move", true);
        PatrolPosition1 = new Vector3(enemyScript.transform.position.x + enemyScript.patrolPoint1,enemyScript.transform.position.y,enemyScript.transform.position.z);
        PatrolPosition2 = new Vector3(enemyScript.transform.position.x + enemyScript.patrolPoint2, enemyScript.transform.position.y, enemyScript.transform.position.z);
        movingToPosition1 = true;
        CurrentPosition = new Vector3(0,0,0);
        characterFlipped = false;
    }

    public void update(EnemyScript enemyScript, Transform playerTransform, float currentHealth, Animator animator)
    {
        CurrentPosition = PatrolPosition1;
        animator.SetBool("Move", true);

        if (movingToPosition1)
        {
            CurrentPosition = PatrolPosition1;
           
        }
        else 
        {
            CurrentPosition = PatrolPosition2;
           
        }
        

        enemyScript.transform.position = Vector3.MoveTowards(enemyScript.transform.position,CurrentPosition,enemyScript.patrolSpeed*Time.deltaTime);

        if (Vector3.Distance(enemyScript.transform.position, CurrentPosition) <= 0f)
        {
            movingToPosition1 = !movingToPosition1;
            characterFlipped = enemyScript.flipCharacter(characterFlipped);
        }
        

        //Transition to Attack
        if (Vector2.Distance(enemyScript.transform.position, playerTransform.transform.position) <= enemyScript.attackRange && enemyScript.attackTimer >= enemyScript.attackCooldown)
        {
            if (characterFlipped)
            {
                movingToPosition1 = !movingToPosition1;
                characterFlipped = enemyScript.flipCharacter(characterFlipped);
            }
            
            enemyScript.changeState(enemyScript.attackState);
        }
        //Transition to dead
        if (currentHealth <= 0)
        {
            enemyScript.changeState(enemyScript.DeadState);
        }
        
    }


    
}
