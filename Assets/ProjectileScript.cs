using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    float delay;
    public float movementSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * Time.deltaTime * movementSpeed;
        
        delay += Time.deltaTime;

        if (delay >= 3.0f)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
