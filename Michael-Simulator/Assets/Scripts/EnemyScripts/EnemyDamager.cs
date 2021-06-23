using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public Rigidbody2D enemyRb;

    [Header("Damage")]
    int damageToGive = 1;

    [Header("KnockBack")]
    int knockBackForce = 20;
    Vector2 movDirKnockBack;

    public bool gotKnockbacked;

    float knockBackTimer = 0.1f;
    float knockBackCurrentTimer;

    // Start is called before the first frame update
    void Start()
    {
        knockBackCurrentTimer = knockBackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        knockBackCurrentTimer -= Time.deltaTime;
        if(knockBackCurrentTimer <= 0)
        {
            gotKnockbacked = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gotKnockbacked = true;
            knockBackCurrentTimer = knockBackTimer;

            collision.gameObject.GetComponent<PlayerController>().playerTakeDamage(damageToGive);
            movDirKnockBack = enemyRb.transform.position - collision.gameObject.transform.position;
            enemyRb.AddForce(movDirKnockBack.normalized * knockBackForce, ForceMode2D.Impulse);
        }
    }
}
