using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private PaddleCollision paddleCollision;

    private bool _shouldFollowNegative = false;

    private void Awake()
    {
        // Half check
        if (transform.position.x < 0)
        {
            _shouldFollowNegative = true;
        }
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        Ball followBall = null;

        // Decide which ball follow based on the half of the paddle
        foreach(Ball ball in MultiballController.Instance.Balls)
        {
            if(ball.gameObject.transform.position.x < 0 && _shouldFollowNegative)
            {
                followBall = ball;
            }
            else if(ball.gameObject.transform.position.x >= 0 && !_shouldFollowNegative)
            {
                followBall = ball;
            }
        }

        // Continue only if it has a ball to follow
        if (followBall == null)
            return;

        // Follow ball
        if(followBall.transform.position.x > this.transform.position.x)
        {
            direction = Vector3.right;
            if (paddleCollision.IsCollidingRight)
                return;
        }
        else
        {
            direction = Vector3.left;
            if (paddleCollision.IsCollidingLeft)
                return;
        }

        // Movment
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
