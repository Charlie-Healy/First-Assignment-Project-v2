using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    
    LayerMask groundLayerMask;
    LayerMask attackLayerMask;
    public void Start()
    {
        
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public bool DoRayCollisionCheck()
    {
        float rayLength = 2f;

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

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs, float rayLength, Vector2 direction )
    {
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, direction, rayLength, attackLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has attacked enemy");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, direction * rayLength, hitColor);

        return hitSomething;

    }



}
