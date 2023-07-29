using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public float maxHealth = 3.0f;
    private float currentHealth;
    private Animator animator;
    private GameObject player;
    public float attackCooldown = 2.0f;
    public float attackTimer = 0.0f;
    public float attackRange = 20.0f;
    public GameObject projectile;
    public Transform spawnPosition;
    IBaseState _baseState;
    public PatrolingState patrolingState = new PatrolingState();
    public AttackState attackState = new AttackState();
    public DeadState DeadState = new DeadState();
    public float patrolPoint1;
    public float patrolPoint2;
    public float patrolSpeed = 2.0f;
    public Transform eyetransform;
   




    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;

        _baseState = patrolingState;
        _baseState.enter(this,animator);
    }

    
    void Update()
    {
       
        _baseState.update(this, player.transform, currentHealth, animator);
         
        attackTimer += Time.deltaTime;
    }



    public void changeState(IBaseState baseState)
    {
        _baseState = baseState;
        _baseState.enter(this,animator);
    }

    public void shootProjectile()
    {
        animator.SetBool("Attack", true);
        if (attackTimer >= attackCooldown)
        {
            
            Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
            attackTimer = 0.0f;
        }
    }

    public delegate IEnumerator Attack(EnemyScript enemyScript, Animator animator);

    public void InitiateAttack(Attack attack,EnemyScript enemyScript,Animator animator)
    {
        StartCoroutine(attack(enemyScript,animator));
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;
            FindObjectOfType<AudioManager>().play("Enemy Hurt");
            if (currentHealth > 0)
            {

                StartCoroutine(PlayHitAnimation());
            }   
        }
    }

    private IEnumerator PlayHitAnimation()
    {
        animator.SetBool("Hit", true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("Hit", false);
    }

    public void destroySelf()
    {
        Destroy(gameObject, 1.0f);
    }
    public bool flipCharacter(bool characterFlipped)
    {
        transform.Rotate(0f, 180f, 0f);
        return !characterFlipped;
    }
}
