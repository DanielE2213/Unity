using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;    
    private float moveInput;

    private Rigidbody2D rb;

    
    private bool onGround;
    private float checkRadius;
    public LayerMask whatIsGround;
    public Transform groundChecker;

    private float jumpTimeCounter;
    public float jumpHeight;
    public float jumpTime;
    private bool isJumping;
    public float timeBoost;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkRadius = 0.5F;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

        onGround = Physics2D.OverlapCircle(groundChecker.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpHeight;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
        
            if (jumpTimeCounter > 0)
            {

                rb.velocity = Vector2.up * (float)(jumpHeight/ (jumpTimeCounter + timeBoost));
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }


    }
}
