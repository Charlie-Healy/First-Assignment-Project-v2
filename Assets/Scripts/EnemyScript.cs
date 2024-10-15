using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer sr;
    Helper helper;
    Animator anim;
    bool isGrounded;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();



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
        if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
            sr.flipY = false;
            anim.SetBool("Run", true);
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

       
    }

}
