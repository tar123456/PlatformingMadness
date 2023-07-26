using UnityEngine;
public class PlayerHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    Animator animator;
    
    void Start()
    {
        CurrentHealth = MaxHealth;
        animator = GetComponent<Animator>();
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
            if (CurrentHealth <= 0)
            {
                animator.SetBool("die", true);
            }
            else
            {
                animator.SetBool("hurt",true);
            }
        }
    }
}
