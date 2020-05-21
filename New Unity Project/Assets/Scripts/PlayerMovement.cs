using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed;
    public float jumpheight;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObject;
    public float checkRadius;

    private Rigidbody2D rb;
    private bool facingright = true;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)  
        {
            isJumping = true;
        }

        if (moveDirection > 0 && !facingright)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingright)
        {
            FlipCharacter();
        }

    
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);




        rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpheight));
        }
        isJumping = false;
    }

    private void FlipCharacter()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }
}
