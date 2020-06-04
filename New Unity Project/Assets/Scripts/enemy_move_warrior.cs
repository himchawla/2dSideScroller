using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class enemy_move_warrior : MonoBehaviour {
    // private int money = 0;
    // Start is called before the first frame update

    public bool moveRight = true;
    public GameObject coin;
    public int coinValue = 2;
    private int money;

    public float mul = 0.03f;
    public float speed = 1f;

    private Rigidbody2D rb;

    public float damage = 5.0f;
    void start () {
        rb = GetComponent<Rigidbody2D> ();
        rb.inertia = 100;
    }

    // Update is called once per frame
    void Update () {
        money = gameManager.Instance.money;

        if (money < 100) {
            speed = (float) (0.5 + speed * money * 0.03);
            GetComponent<Animator> ().speed = (float) (1 + speed * money * mul);
        } else {
            speed = 4.0f * speed;
        }
        if (moveRight) {
            transform.Translate (2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (-1.8f, 1.8f);
        } else {
            transform.Translate (-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (1.8f, 1.8f);
        }
    }

    void OnTriggerEnter2D (Collider2D trig) {
        if (trig.gameObject.CompareTag ("turn") || trig.gameObject.CompareTag ("Enemy")) {
            if (moveRight)
                moveRight = false;
            else
                moveRight = true;
        }

        if (trig.gameObject.CompareTag ("JumpRight")) {
            int nCh = Random.Range (1, 3);
            if (nCh == 1) {
                if (moveRight)
                    moveRight = false;
                else
                    moveRight = true;
            }
            
            else
                transform.position = new Vector3 (transform.position.x + 0.2f, transform.position.y + 1.2f, transform.position.z);

        }

        if (trig.gameObject.CompareTag ("JumpLeft")) {
             int nCh = Random.Range (1, 3);
            if (nCh == 1) {
                if (moveRight)
                    moveRight = false;
                else
                    moveRight = true;
            }
            
            else
            transform.position = new Vector3 (transform.position.x - 0.2f, transform.position.y + 1.2f, transform.position.z);
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag ("Enemy")) {
            if (moveRight) {
                moveRight = false;
                transform.Translate (0.2f, 0, 0);
            } else {
                moveRight = true;
                transform.Translate (-0.2f, 0, 0);
            }
        } else if (other.gameObject.CompareTag ("GroundCheck")) {
            for (int i = 0; i < coinValue; i++) {
                Instantiate (coin, new Vector3 (transform.position.x + i, transform.position.y, 0.0f), Quaternion.identity);
            }
            Destroy (gameObject);
        } else if (other.gameObject.CompareTag ("Player")) {
            if (other.gameObject.GetComponent<PlayerMovement> ().isAttacking) {
                for (int i = 0; i < coinValue; i++) {
                    Instantiate (coin, new Vector3 (transform.position.x + i, transform.position.y, 0.0f), Quaternion.identity);
                }
                waveManager.Instance.currEnemies[0]--;
                Destroy (gameObject);
            } else

                other.gameObject.GetComponent<PlayerMovement> ().damagePlayer (damage);
        }
    }

    private void OnCollisionStay2D (Collision2D other) {
        if (other.gameObject.CompareTag ("Enemy")) {
            if (moveRight) {
                moveRight = false;
                transform.Translate (0.5f, 0, 0);
            } else {
                moveRight = true;
                transform.Translate (-0.5f, 0, 0);
            }
        }
    }

}