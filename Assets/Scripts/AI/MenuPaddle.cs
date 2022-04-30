using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPaddle : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private PaddleCollision paddleCollision;

    private MenuBall _followBall;
    private Vector3 _direction = Vector3.zero;

    private void Awake()
    {
        _followBall = FindObjectOfType<MenuBall>();
    }

    void Update()
    {
        // Follow ball
        if (_followBall.transform.position.x > this.transform.position.x)
        {
            _direction = Vector3.right;
            if (paddleCollision.IsCollidingRight)
                return;
        }
        else
        {
            _direction = Vector3.left;
            if (paddleCollision.IsCollidingLeft)
                return;
        }

        // Movment
        transform.Translate(_direction * speed * Time.deltaTime);
    }
}
