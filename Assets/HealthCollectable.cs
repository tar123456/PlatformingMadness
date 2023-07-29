using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    private int currentHealth = 0;
    private int maxHealth = 0;
    public HealthBar healthBar;
    

    private void Start()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().play("Collectable");
            currentHealth = collision.gameObject.GetComponent<PlayerHealthManager>().CurrentHealth;
            maxHealth = collision.gameObject.GetComponent<PlayerHealthManager>().MaxHealth;
            if (currentHealth < maxHealth)
            {
                
                collision.gameObject.GetComponent<PlayerHealthManager>().CurrentHealth = currentHealth+1;
                healthBar.setHealth(currentHealth+1);
            }
            Destroy(gameObject);
        }
    }
}
