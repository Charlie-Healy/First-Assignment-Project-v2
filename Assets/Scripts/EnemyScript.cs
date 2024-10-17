using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    SpriteRenderer sr;
    Helper helper;
    Animator anim;
    bool isGrounded;
    Rigidbody2D rb;
    bool isJumping;
    Vector2 lastPos;


    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //isJumping = false;


        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = false;
            sr.flipY = false;
            //anim.SetBool("Run" , false );  
        }
        else
        {
            //anim.SetBool("Run", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dx = lastPos.x - transform.position.x;
        float dy = lastPos.y - transform.position.y;

        anim.SetBool("Run", false);

        print("dxy= " + dx + " " + dy);

        if (dy < -0.5f || dy > 0.5f)
        {
            //if (player.transform.position.y > transform.position.y)
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Run", false);
            }
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if ( dx<-0.2f || dx>0.2f )
        {
            sr.flipX = true;
            sr.flipY = false;
            anim.SetBool("Run", true);
            anim.SetBool("Jump", false);

        }
        else
        {
            sr.flipX = false;
            sr.flipY = false;
        }
        

        if (player.transform.position.y < transform.position.y)
        {
            sr.flipY = false;
        }

        helper.DoRayCollisionCheck();

       lastPos = transform.position;
    }

}
