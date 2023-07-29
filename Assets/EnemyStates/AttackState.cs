using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : IBaseState
{
    bool isAttacking;
    public void enter(EnemyScript enemyScript, Animator animator)
    {
        animator.SetBool("Move", false);
        isAttacking = false;

    }

    public void update(EnemyScript enemyScript, Transform playerTransform, float currentHealth, Animator animator)
    {
        int playerLayerMask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(enemyScript.eyetransform.position, enemyScript.eyetransform.right, enemyScript.attackRange+1f, playerLayerMask);
        Debug.DrawRay(enemyScript.eyetransform.position, enemyScript.eyetransform.right * enemyScript.attackRange, Color.red);
        Debug.Log(hit.collider != null ? hit.collider : "no hit");
        if (hit.collider == null)
        {
            
            // If the player is not within attack range, transition back to patrolling state
            enemyScript.changeState(enemyScript.patrolingState);
            
        }

        else
        {
            
            float distanceToPlayer = Vector2.Distance(hit.point, enemyScript.eyetransform.position);
            if (distanceToPlayer <= enemyScript.attackRange)
            {
               
                isAttacking = true;
            }
           
            
        }

        if (isAttacking)
        {
            enemyScript.InitiateAttack(Attack, enemyScript, animator);
        }
       





        //Transition to dead
        if (currentHealth <= 0)
        {
            enemyScript.changeState(enemyScript.DeadState);
        }
    }

    private IEnumerator Attack(EnemyScript enemyScript, Animator animator)
    {
                
        yield return new WaitForSeconds(0.1f);

        enemyScript.shootProjectile();

        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("Attack", false);

    }
    

}
