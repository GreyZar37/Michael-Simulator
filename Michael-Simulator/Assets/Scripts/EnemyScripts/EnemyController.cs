using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController: MonoBehaviour
{

    [Header("Enemy Controller")]

    public float speed;
    public float distance;
    
    private bool movingRight = true;

    public Transform groundDetection;

    Rigidbody2D rb;

    EnemyDamager dm;

    [Header("Health")]
    int maxHealth = 3;
    int currentHealth;

    void Start()
    {
        dm = GetComponent<EnemyDamager>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(dm.gotKnockbacked == true)
        {

        }
        else
        {
            rb.velocity = transform.right * speed;
        }
        
        


        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180,0);
                movingRight = false;
            }
            else if (movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    public void enemyTakeDamage(int damage)
    {
        currentHealth -= damage;
        print(currentHealth);
    }
}

