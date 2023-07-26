using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IBaseState
{
    public void enter(EnemyScript enemyScript, Animator animator)
    {
        Debug.Log("Dead");
    }

    public void update(EnemyScript enemyScript, Transform playerTransform, float currentHealth, Animator animator)
    {
        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
        animator.SetBool("Die", true);
        enemyScript.destroySelf();

    }
   

}
