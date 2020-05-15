﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
   // private int money = 0;
    // Start is called before the first frame update
    
    public bool moveRight = true;

    private int money;
    public float speed = 0.5f;
    void start()
    {
    
    }

     
    // Update is called once per frame
    void Update()
    {
        money = gameManager.Instance.money;
      
     
     if(money<100)
     {
        speed = (float)(0.5 + money * 0.03);
     }
     else
        {
            speed = 4.0f;
        }
        if(moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (-4,4);
        }
        else
        {
            transform.Translate( - 2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (4,4);
        }
    }


      void OnTriggerEnter2D(Collider2D trig) {
            if(trig.gameObject.CompareTag("turn"))
            {
                if(moveRight)
                moveRight = false;
                else 
                moveRight = true;
            }
        }
}