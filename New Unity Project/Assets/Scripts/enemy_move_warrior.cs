using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class enemy_move_warrior : MonoBehaviour
{
   // private int money = 0;
    // Start is called before the first frame update
    
    public bool moveRight = true;

    public int coinValue = 1;
    private int money;

    public float mul = 0.03f;
    public float speed = 1f;

    public float damage = 5.0f;
    void start()
    {
    
    }

     
    // Update is called once per frame
    void Update()
    {
        money = gameManager.Instance.money;
      
     
     if(money<100)
     {
        speed = (float)(0.5 + speed*money * 0.03);
        GetComponent<Animator>().speed = (float)(1 + speed * money * mul);
     }
     else
        {
            speed = 4.0f * speed;
        }
        if(moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (-1,1);
        }
        else
        {
            transform.Translate( - 2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (1,1);
        }
    }




      void OnTriggerEnter2D(Collider2D trig) {
            if(trig.gameObject.CompareTag("turn") || trig.gameObject.CompareTag("Enemy"))
            {
                if(moveRight)
                moveRight = false;
                else 
                moveRight = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.CompareTag("Enemy"))
            {
                if(moveRight)
                {
                    moveRight = false;
                    transform.Translate(0.2f,0,0);
                }
                else 
                {
                    moveRight = true;
                    transform.Translate(-0.2f,0,0);
                }
            }
            else if(other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerMovement>().damagePlayer(damage);
        }

        private void OnCollisionStay2D(Collision2D other) {
            if(other.gameObject.CompareTag("Enemy"))
            {
                if(moveRight)
                {
                    moveRight = false;
                    transform.Translate(0.5f,0,0);
                }
                else 
                {
                    moveRight = true;
                    transform.Translate(-0.5f,0,0);
                }
            }
        }
        
 

}