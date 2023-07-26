
using UnityEngine;

public interface IBaseState
{
    public void enter(EnemyScript enemyScript, Animator animator);
    public void update(EnemyScript enemyScript, Transform playerTransform, float currentHealth, Animator animator);

   
}
