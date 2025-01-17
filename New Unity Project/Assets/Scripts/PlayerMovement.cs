﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float jumpHeight = 300;
    public int jumpCounter = 0;
    public int maxJumpCounter = 2;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObject;
    public float checkRadius = 1;
    public float fallingMultiplier = 2.5f;
    public bool isAttacking;
    private float attackTimer;
    public float shortJumpMultiplier = 2.0f;
    public GameObject telarena1;
    public GameObject telarena2;
    public Animator animator;
    public bool isDamaged;
    public bool isDead;
    public healthBarScript healthbar;
    private float damageTimer = 0.0f;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthbar.setMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        isDamaged = false;
        attackTimer-=Time.deltaTime;
        if(attackTimer<=0)
        {
            isAttacking = false;
            gameManager.Instance.isAttacking = false;
        }
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && (jumpCounter < maxJumpCounter))  
        {
            isJumping = true;
            jumpCounter++;
        }

        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }

        if(rb.velocity.y < 0.0f)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallingMultiplier - 1) * Time.deltaTime;
        }

        else if(rb.velocity.y> 0.0f && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (shortJumpMultiplier - 1) * Time.deltaTime;            
        }

        if(Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            gameManager.Instance.isAttacking = true;
            attackTimer = 0.3f;
            

        }

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        
        animator.SetBool("IsAttacking", isAttacking);
       
        animator.SetBool("PlayerDead", isDead);
    }


        void OnTriggerEnter2D(Collider2D trig) {
            if(trig.gameObject.CompareTag("1-2Wall"))
            {
                if(gameManager.Instance.aren == gameManager.arena.arena1)
                {
                    gameManager.Instance.aren = gameManager.arena.arena2;
                    arenaManager.Instance.arena2Begin();
                }
                if(gameManager.Instance.aren == gameManager.arena.arena2)
                {
                    gameManager.Instance.aren = gameManager.arena.arena1;
                    arenaManager.Instance.arena2Begin();
                }
                
            }

            if(trig.gameObject.CompareTag("arena1Confirmation"))
            {
                gameManager.Instance.aren = gameManager.arena.arena1;
                arenaManager.Instance.arena1Begin();
            }
        
            if(trig.gameObject.CompareTag("arena2Confirmation"))
            {
                gameManager.Instance.aren = gameManager.arena.arena2;
                arenaManager.Instance.arena2Begin();
            }
        
       
        if(trig.gameObject.CompareTag("3-4Wall"))
            {
                if(gameManager.Instance.aren == gameManager.arena.arena3)
                {
                    gameManager.Instance.aren = gameManager.arena.arena4;
                }
                if(gameManager.Instance.aren == gameManager.arena.arena4)
                {
                    gameManager.Instance.aren = gameManager.arena.arena3;
                }
                
            }

        if(trig.gameObject.CompareTag("arena2Fall"))
        {
            arenaManager.Instance.arena2Flag = true;
        }

            if(trig.gameObject.CompareTag("arena3Confirmation"))
            {
                gameManager.Instance.aren = gameManager.arena.arena3;
                arenaManager.Instance.arena3Begin();

            }
        
            if(trig.gameObject.CompareTag("arena4Confirmation"))
            {
                gameManager.Instance.aren = gameManager.arena.arena4;
                arenaManager.Instance.arena4Begin();

            }
        

            if(trig.gameObject.CompareTag("arena1Vertical"))
            {
                gameManager.Instance.aren = gameManager.arena.arena1;
                transform.position = telarena1.transform.position;
                rb.velocity = new Vector2(0.0f,0.0f);
                arenaManager.Instance.arena1Begin();

            
            }
        
            if(trig.gameObject.CompareTag("arena2Vertical"))
            {
                gameManager.Instance.aren = gameManager.arena.arena2;
                transform.position = telarena2.transform.position;
                rb.velocity = new Vector2(0.0f,0.0f);
                arenaManager.Instance.arena2Begin();

            }

        }


        

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);


        damageTimer -= Time.deltaTime;
        if(damageTimer<=0)
        {
            animator.SetBool("PlayerHit", false);
        }

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            isGrounded = false;
            isJumping = false;
        }
        if (isGrounded)
        {
            jumpCounter = 0;
            animator.SetBool("IsJumping", false);
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    public void damagePlayer(float damage)
    {
        if(gameManager.Instance.health - damage > 0)
        {
            damageTimer = 0.2f;
            gameManager.Instance.health -= damage;
            isDamaged = true;
            animator.SetBool("PlayerHit", true);
            healthbar.setHealth((int)gameManager.Instance.health);
        }
        else 
        {
            isDead = true;
            gameManager.Instance.gameOver();
        }
    }
}
