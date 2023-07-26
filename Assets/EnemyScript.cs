using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public float maxHealth = 3.0f;
    private float currentHealth;

    private Animator animator;
    private GameObject player;
    private bool isAttacking = false;

    
    public float attackCooldown = 2.0f;
    private float attackTimer = 0.0f;

    
    public float attackRange = 20.0f;

    public GameObject projectile;

    public Transform spawnPosition;

    public Transform[] waypoints;
    

    
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        if (!isAttacking && CanAttackPlayer())
        {
            
            StartCoroutine(Attack());
            
        }

        
        attackTimer += Time.deltaTime;
    }

    private bool CanAttackPlayer()
    {
        
        return (Vector2.Distance(transform.position, player.transform.position) <= attackRange && attackTimer >= attackCooldown);
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(0.1f);

        Instantiate(projectile, spawnPosition.position, transform.rotation);

        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
       

        animator.SetBool("Attack", false);
        isAttacking = false;

        
        attackTimer = 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                animator.SetBool("Die", true);
                Destroy(gameObject, 1.0f); 
            }
            else
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
}
