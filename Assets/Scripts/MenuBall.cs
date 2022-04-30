using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour
{
    public Vector2 Velocity { get => _velocity; set => _velocity = value; }

    [Header("Default Parameters")]
    [SerializeField]
    private LayerMask ballLayerMask;

    [Header("Audio Parameters")]
    [SerializeField]
    private AudioClip onWallHitAudio;
    [SerializeField]
    private AudioClip onPaddleHitAudio;

    [Header("Particles")]
    [SerializeField]
    private ParticleSystem hitSmoke;

    private Vector2 _velocity = new Vector2(4, 4);

    private CircleCollider2D _circleCollider;
    private GameObject _lastObjectHit;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        _velocity = new Vector2(4, 4);
    }

    private void Update()
    {
        transform.Translate(_velocity * Time.deltaTime);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _circleCollider.radius, _velocity, (_velocity * Time.deltaTime).magnitude, ballLayerMask);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != _circleCollider && hit.transform.gameObject != _lastObjectHit)
            {
                bool isBlock = false;

                _lastObjectHit = hit.transform.gameObject; // Avoiding hitting twice the same object
                _velocity = Vector2.Reflect(_velocity, hit.normal);

                if (hit.transform.GetComponent<Paddle>())
                {
                    _velocity.y = Mathf.Abs(_velocity.y); // Always positive, travel upwards
                    AudioController.Instance.PlayClip(onPaddleHitAudio);
                }

                AudioController.Instance.PlayClip(onWallHitAudio);

                if (!isBlock)
                {
                    // Particle
                    Instantiate(hitSmoke, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
