using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    LayerMask groundLayerMask;

    public void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public bool DoRayCollisionCheck()
    {
        float rayLength = 2.5f;

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;

        }

        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);

        return hit.collider;

    }
    public void Test()
    {
        if (Input.GetKey("h") == true)
        {
            print("hello");
        }
    }

}
