using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] float patrolSpeed;

    float currentSpeed;
    private Animator anim;

    Helper helper;
    Rigidbody2D rb;
    SpriteRenderer sr;


    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        currentSpeed = patrolSpeed;

    }
    void Update()
    {
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        EnemyPatrol();
    }
    public void EnemyPatrol()
    {
        bool lefthit = helper.ExtendedRayCollisionCheck(-1f, -1f, 2, Vector2.down);
        bool righthit = helper.ExtendedRayCollisionCheck(1f, -1f, 2, Vector2.down);
        
        anim.SetBool("Run" , true);

        if(currentSpeed < 0f && !lefthit)
        {
            transform.localScale = new Vector3(10,10,1);
            currentSpeed = patrolSpeed;
        }
        else if (currentSpeed > 0f && !righthit)
        {
            transform.localScale = new Vector3(10, 10, 1);
            currentSpeed = -patrolSpeed;
        }
        if (gameObject.tag == ("Respawn"))
        {
            transform.localScale = new Vector3(10, 10, 1);
            //patrolSpeed = -patrolSpeed;
        }
    }
}
