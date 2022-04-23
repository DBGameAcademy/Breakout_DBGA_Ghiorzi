using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Warp : MonoBehaviour
{
    [SerializeField]
    private Warp otherWarp;

    [SerializeField]
    private ParticleSystem particle;

    private CircleCollider2D _circleCollider2D;

    public void WarpBall(Ball ball)
    {
        _circleCollider2D.enabled = false;
        ball.gameObject.transform.position = this.transform.position;
        StartCoroutine(COWaitToActive(1.0f));

        particle.Play();
    }

    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            particle.Play();
            
            Ball ball = collision.gameObject.GetComponent<Ball>();
            otherWarp.WarpBall(ball);
        }
    }

    private IEnumerator COWaitToActive(float delay)
    {
        yield return new WaitForSeconds(delay);
        _circleCollider2D.enabled = true;
    }
}
