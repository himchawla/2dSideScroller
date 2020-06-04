using Pathfinding;
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
    public GameObject coin;
    public int coinValue = 2;
    private int money;
    public GameObject player;
    public float mul = 0.03f;
    public float speed = 1f;
    public AIPath aiPath;

    bool canDie;

    private Rigidbody2D rb;

    public float damage = 5.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.inertia = 100;
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<AIDestinationSetter>().target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        money = gameManager.Instance.money;

        if (money < 25)
        {
            speed = (float)(0.5 + speed * money * 0.03);
            GetComponent<AIPath>().maxSpeed = speed * 4;
            GetComponent<Animator>().speed = (float)(1 + speed * money * mul);
        }
        else
        {
            speed = 2.0f * speed;
            GetComponent<AIPath>().maxSpeed = speed * 4;

        }
        if (aiPath.desiredVelocity.x <= -0.01)
        {
            //  transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1.8f, 1.8f);
        }
        else if (aiPath.desiredVelocity.x >= 0.01)
        {
            //transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1.8f, 1.8f);
        }
        if (canDie && gameManager.Instance.isAttacking)
        {

            for (int i = 0; i < coinValue; i++)
            {
                Instantiate(coin, new Vector3(transform.position.x + i, transform.position.y, 0.0f), Quaternion.identity);
            }
            waveManager.Instance.currEnemies[0]--;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn") || trig.gameObject.CompareTag("Enemy"))
        {
            if (moveRight)
                moveRight = false;
            else
                moveRight = true;
        }

        //if (trig.gameObject.CompareTag ("JumpRight")) {
        //    int nCh = Random.Range (1, 3);
        //    if (nCh == 1) {
        //        if (moveRight)
        //            moveRight = false;
        //        else
        //            moveRight = true;
        //    }

        //    else
        //        transform.position = new Vector3 (transform.position.x + 0.2f, transform.position.y + 1.2f, transform.position.z);

        //}

        //if (trig.gameObject.CompareTag ("JumpLeft")) {
        //     int nCh = Random.Range (1, 3);
        //    if (nCh == 1) {
        //        if (moveRight)
        //            moveRight = false;
        //        else
        //            moveRight = true;
        //    }

        //    else
        //    transform.position = new Vector3 (transform.position.x - 0.2f, transform.position.y + 1.2f, transform.position.z);
        //}

        if (trig.gameObject.CompareTag("playerAttack"))
        {

            canDie = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerAttack"))
        {
            canDie = false;
        }
    }

    private void onTriggerStay2D(Collision2D trig)
    {


        //if (trig.gameObject.CompareTag("turn") || trig.gameObject.CompareTag("Enemy"))
        //{
        //    if (moveRight)
        //        moveRight = false;
        //    else
        //        moveRight = true;
        //}

        //if (trig.gameObject.CompareTag("JumpRight"))
        //{
        //    int nCh = Random.Range(1, 3);
        //    if (nCh == 1)
        //    {
        //        if (moveRight)
        //            moveRight = false;
        //        else
        //            moveRight = true;
        //    }

        //    else
        //        transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 1.2f, transform.position.z);

        //}

        //if (trig.gameObject.CompareTag("JumpLeft"))
        //{
        //    int nCh = Random.Range(1, 3);
        //    if (nCh == 1)
        //    {
        //        if (moveRight)
        //            moveRight = false;
        //        else
        //            moveRight = true;
        //    }

        //    else
        //        transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y + 1.2f, transform.position.z);
        //}

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag ("Enemy")) {
        //    if (moveRight) {
        //        moveRight = false;
        //        transform.Translate (0.2f, 0, 0);
        //    } else {
        //        moveRight = true;
        //        transform.Translate (-0.2f, 0, 0);
        //    }
        //} else if (other.gameObject.CompareTag ("GroundCheck")) {
        //    for (int i = 0; i < coinValue; i++) {
        //        Instantiate (coin, new Vector3 (transform.position.x + i, transform.position.y, 0.0f), Quaternion.identity);
        //    }
        //    Destroy (gameObject);
     if (other.gameObject.CompareTag ("Player")) {

            other.gameObject.GetComponent<PlayerMovement>().damagePlayer(damage); }
    //}
}

    private void OnCollisionStay2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag ("Enemy")) {
        //    if (moveRight) {
        //        moveRight = false;
        //        switch (gameManager.Instance.aren)
        //        {
        //            case gameManager.arena.arena1:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena1[0].transform.position;
        //                }
        //                break;

        //            case gameManager.arena.arena2:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena2[0].transform.position;
        //                }
        //                break;
        //            case gameManager.arena.arena3:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena3[0].transform.position;
        //                }
        //                break;
        //            case gameManager.arena.arena4:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena4[0].transform.position;
        //                }
        //                break;
        //        }
        //        } else {
        //        moveRight = true;

        //        switch (gameManager.Instance.aren)
        //        {
        //            case gameManager.arena.arena1:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena1[2].transform.position;
        //                }
        //                break;

        //            case gameManager.arena.arena2:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena2[1].transform.position;
        //                }
        //                break;
        //            case gameManager.arena.arena3:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena3[3].transform.position;
        //                }
        //                break;
        //            case gameManager.arena.arena4:

        //                {
        //                    transform.position = waveManager.Instance.spawnPointsArena4[1].transform.position;
        //                }
        //                break;
        //        }

        //        transform.Translate (-0.5f, 0, 0);
        //    }
        //    }
        //}

    }
}