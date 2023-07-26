using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : IBaseState
{
    public void enter(EnemyScript enemyScript, Animator animator)
    {
        animator.SetBool("Move", false);
    }

    public void update(EnemyScript enemyScript, Transform playerTransform, float currentHealth, Animator animator)
    {
        
        enemyScript.InitiateAttack(Attack,enemyScript,animator);
        

        //Transition to Patrol
        if (Vector2.Distance(enemyScript.transform.position, playerTransform.transform.position) > enemyScript.attackRange || enemyScript.attackTimer > enemyScript.attackCooldown)
        {
            enemyScript.changeState(enemyScript.patrolingState);
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
