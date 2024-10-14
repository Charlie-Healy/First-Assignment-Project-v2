using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer sr;
    Helper helper;



    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        sr = GetComponent<SpriteRenderer>();



        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (player.transform.position.y < transform.position.y)
        {
            sr.flipY = true;
        }

        helper.DoRayCollisionCheck();

       
    }

}
