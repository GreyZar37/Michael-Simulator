using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject enemy;
    void Start()
    {
        
    }

    void Update()
    {
        enemy.transform.position = new Vector2((speed * Time.deltaTime + enemy.transform.position.x), transform.position.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = speed*-1;
    }
}
