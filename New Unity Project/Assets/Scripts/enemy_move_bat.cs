using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class enemy_move_bat : MonoBehaviour
{
   // private int money = 0;
    // Start is called before the first frame update
    
    public bool moveRight = true;

    private int money;
    public float speed = 1.0f;

    public float gravity = 1.0f;

    public float maxHeight = 3.0f;

    public float currHeight = 0.0f;
    void start()
    {
        currHeight = 0;
    }

   
    // Update is called once per frame
    void Update()
    {
        money = gameManager.Instance.money;
      
     
     if(money<100)
     {
        speed = (float)(1.0 + money * 0.03);
        if(currHeight <=0 && gravity<0)
                {gravity = speed;}
        if(currHeight >= maxHeight && gravity > 0)
                {gravity = -speed;}
     }
     else
        {
            speed = 5.0f;
            if(currHeight <=0 && gravity<0)
                gravity = speed;
            if(currHeight >= maxHeight && gravity > 0)
                gravity = -speed;
        }
        if(moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, Time.deltaTime * gravity, 0);
            transform.localScale = new Vector2 (-1,1);
            
            currHeight+=Time.deltaTime*gravity;
        }
        else
        {
            transform.Translate( - 2 * Time.deltaTime * speed, Time.deltaTime * gravity, 0);
            transform.localScale = new Vector2 (1,1);
            currHeight+=Time.deltaTime*gravity;
        }

        // if((currHeight <=0 && gravity<0) || (currHeight>=maxHeight && gravity >0))
        // gravity = -gravity;



    }

    

private void OnCollisionEnter2D(Collision2D other) {
    
    if(other.gameObject.CompareTag("Ground"))
    {
    if(moveRight)
    moveRight = false;
    else moveRight = true;
    }

   

//       void OnTriggerEnter2D(Collider2D trig) {
//             if(true)
//             {
//                 if(moveRight)
//                 moveRight = false;
//                 else 
//                 moveRight = true;
//             }
//         }
 }
}
