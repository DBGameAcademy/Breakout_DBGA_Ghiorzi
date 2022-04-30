using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCollision : MonoBehaviour
{
    public bool IsCollidingLeft { get; private set; }
    public bool IsCollidingRight { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.ToLower().Equals("wall") || 
            collision.gameObject.tag.ToLower().Equals("paddle"))
        {
            ContactPoint2D contactPoint = collision.GetContact(0);

            if(contactPoint.point.x > transform.position.x)
            {
                // Right
                IsCollidingLeft = false;
                IsCollidingRight = true;
            }
            else
            {
                // Left
                IsCollidingLeft = true;
                IsCollidingRight = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.ToLower().Equals("wall") || 
            collision.gameObject.tag.ToLower().Equals("paddle"))
        {
            ContactPoint2D contactPoint = collision.GetContact(0);

            if (contactPoint.point.x > transform.position.x)
            {
                // Right
                IsCollidingLeft = false;
                IsCollidingRight = true;
            }
            else
            {
                // Left
                IsCollidingLeft = true;
                IsCollidingRight = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsCollidingLeft = false;
        IsCollidingRight = false;
    }
}
