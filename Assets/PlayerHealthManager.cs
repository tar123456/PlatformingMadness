using UnityEngine;
public class PlayerHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    Animator animator;
    public HealthBar healthBar;
    public GameOverScript gameOverScript;
    
    void Start()
    {
        CurrentHealth = MaxHealth;
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("EnemyProjectile"))
        {
            
            CurrentHealth--;
            healthBar.setHealth(CurrentHealth);
            if (CurrentHealth <= 0)
            {

                animator.SetBool("die", true);
                gameOverScript.showGameOverScreen();
            }
            else
            {
                animator.SetBool("hurt",true);
            }
        }
    }
}
