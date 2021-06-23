using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [Header("Damage and Speed")]
 
    public float bulletSpeed = 0f;
    public int playerDamage = 1;
   

    [Header("RB and Gameobjects")]

    public GameObject bullet;
    public Rigidbody2D rb;
    

    [Header("Timer")]

    float currentTimer;
    float endTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTimer = endTimer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if(currentTimer <= 0)
        {
            Destroy(this.gameObject);
        }
        rb.velocity = transform.right * bulletSpeed;
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyController>().enemyTakeDamage(playerDamage);
            print("hit");

        }
        else
        {
            Destroy(gameObject);

        }
    }

   
}
