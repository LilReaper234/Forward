using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    
    private float move;
    
    private Rigidbody2D rb;
    public Animator animator;

    public bool isJumping;
    public bool isSprinting;
    public bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(move));

        if (Input.GetKeyDown("left shift"))
        {
            isSprinting = true;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            isSprinting = false;
        }

        if (isSprinting == true)
        {
            speed = 10;
        }
        else if (isSprinting == false)
        {
            speed = 5;
        }

        if (move > 0 && facingRight)
        {
            Flip();
        }

        if (move < 0 && !facingRight)
        {
            Flip();
        }
    }



    void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
