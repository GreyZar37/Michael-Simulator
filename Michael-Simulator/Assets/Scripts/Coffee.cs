using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public int wetness;
    public int maxRefreshmentLevel;
    public int currentBulletsLeft;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            currentBulletsLeft = maxRefreshmentLevel;
        }
    }
}
