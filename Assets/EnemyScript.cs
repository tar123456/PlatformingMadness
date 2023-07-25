using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool collidedWithProjectile = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        collidedWithProjectile = collision.gameObject.CompareTag("Projectile");
        
        if (collidedWithProjectile)
        {
            
            Destroy(gameObject);
        }
    }
}
