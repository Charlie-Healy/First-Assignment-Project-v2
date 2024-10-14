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
    bool isAttacking;
    bool isTeleport;
    int jumpForce = 10;

    //float speed
    float speed;

    Helper helper;
    LayerMask attackLayerMask;



    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        attackLayerMask = LayerMask.GetMask("Attack");

        //isAttacking = false;
        //isGrounded = false;
        //isJumping = false;
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
        DoAttack();
        TeleportPlayer();
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
            rb.velocity = new Vector2(-13f, rb.velocity.y);
            sr.flipX = true;
        }
        if (Input.GetKey("d") == true)
        {
            print("player pressed d");
            rb.velocity = new Vector2(13f, rb.velocity.y);
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

    void DoAttack()
    {
        if (Input.GetKeyDown("f") == true)
        {
            
            print("player pressed attack");
            anim.SetTrigger("attack");
            


        }
    }

    void TeleportPlayer()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) == true && rb.velocity.x > 0.2f)
        {
            transform.position=new Vector3(transform.position.x+10f, transform.position.y);
            isTeleport = true;
            anim.SetBool("teleport" , true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) == true && rb.velocity.x < -0.2f)
        {
            transform.position = new Vector3(transform.position.x -10f, transform.position.y);
            isTeleport = true;
            anim.SetBool("teleport", true);
        }

    }
    
    

    public void AttackFrame()
    {
        //do a raycast towards the enemy
        print("attack frame!!");

        helper.ExtendedRayCollisionCheck( 0,0, 2, Vector2.right);
        
    }


}
