using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;
    bool isGrounded;
    bool isJumping;
    int jumpForce = 10;

    //float speed
    float speed;

    Helper helper;



    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        isGrounded = false;
        isJumping = false;
        speed = 5.0f;
    }
    public void Update()
    {
        if (Input.GetKey("h") == true)
        {
            helper.Test();
            //helper.Flip(true);
        }
        helper.DoRayCollisionCheck();
        MoveSprite();
        DoJump();
        DoLand();
    }

    void DoJump()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector3(0, 3, 0) * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            anim.SetBool("walk", false);
            isJumping = true;
        }
    }

    void DoLand()
    {
        if (isGrounded && isJumping && rb.velocity.y <= 0)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

    }


    void MoveSprite()
    {
        isGrounded = helper.DoRayCollisionCheck();

        if (Input.GetKey("a") == true)
        {
            print("player pressed a");
            rb.velocity = new Vector2(-8f, rb.velocity.y);
            sr.flipX = true;
        }
        if (Input.GetKey("d") == true)
        {
            print("player pressed d");
            rb.velocity = new Vector2(8f, rb.velocity.y);
            sr.flipX = false;
        }

        anim.SetBool("walk", false);

        if (isJumping == false)
        {
            if (rb.velocity.x > 0.2f || rb.velocity.x < -0.2f)
            {
                anim.SetBool("walk", true);
            }
        }
    }


}
