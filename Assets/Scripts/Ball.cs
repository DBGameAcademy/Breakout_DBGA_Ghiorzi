using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 Velocity { get => _velocity; set => _velocity = value; }

    [Header("Default Parameters")]
    [SerializeField]
    private Vector3 ballResetPosition;
    [SerializeField]
    private Vector2 defaultVelocity = new Vector2(4, 4);
    [SerializeField]
    private LayerMask ballLayerMask;

    [Header("Audio Parameters")]
    [SerializeField]
    private AudioClip onWallHitAudio;
    [SerializeField]
    private AudioClip onPaddleHitAudio;

    [Header("Velocity Change Parameters")]
    [SerializeField]
    private int thresholdRange = 200;
    [SerializeField]
    private float velocityMultiplier = 1.3f;

    [Header("Particles")]
    [SerializeField]
    private ParticleSystem hitSmoke;

    private int _minScoreThreshold = 200;
    private int _maxScoreThreshold;

    private Vector2 _velocity;

    private CircleCollider2D _circleCollider;
    private GameObject _lastObjectHit;

    private int _ballDamage = 1;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        ResetVelocity();
        _ballDamage = 1;
    }

    private void Update()
    {
        transform.Translate(_velocity * Time.deltaTime);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _circleCollider.radius, _velocity, (_velocity * Time.deltaTime).magnitude, ballLayerMask);

        foreach(RaycastHit2D hit in hits)
        {
            if(hit.collider != _circleCollider && hit.transform.gameObject != _lastObjectHit)
            {
                bool isBlock = false;

                _lastObjectHit = hit.transform.gameObject; // Avoiding hitting twice the same object
                _velocity = Vector2.Reflect(_velocity, hit.normal);

                if (hit.transform.GetComponent<Paddle>())
                {
                    _velocity.y = Mathf.Abs(_velocity.y); // Always positive, travel upwards
                    AudioController.Instance.PlayClip(onPaddleHitAudio);
                }

                if (hit.transform.GetComponent<Block>())
                {
                    hit.transform.GetComponent<Block>().OnHit(_ballDamage);
                    isBlock = true; 
                }
                AudioController.Instance.PlayClip(onWallHitAudio);

                if (!isBlock)
                {
                    // Particle
                    Instantiate(hitSmoke, hit.point, Quaternion.identity);
                }
            }
        }

        if (transform.position.y < -Camera.main.orthographicSize)
        { 
            GameController.Instance.BallLost(this);
        }

        // Update Velocity
        UpateVelocity();
    }

    public void BallReset()
    {
        if(MultiballController.Instance.BallCount >= 2)
        {
            MultiballController.Instance.RemoveBall(this);
            Destroy(gameObject);
        }
        else
        {
            // Reset position
            transform.position = ballResetPosition;

            // Travel up when reset
            Vector3 currentVelocity = _velocity;
            currentVelocity.y = Mathf.Abs(currentVelocity.y);
            _velocity = currentVelocity;

            // Reset last object hit
            _lastObjectHit = null;
        }
       
    }

    public void ResetVelocity()
    {
        _velocity = defaultVelocity;
        _minScoreThreshold = thresholdRange;
        _maxScoreThreshold = _minScoreThreshold + thresholdRange;
    }

    public void SetBallDamage(int damage)
    {
        if (damage < 0)
            damage = 1;
        _ballDamage = damage;
    }

    public void ResetBallDamage()
    {
        _ballDamage = 1;
    }

    private void UpateVelocity()
    {
        if(GameController.Instance.Score >= _minScoreThreshold && GameController.Instance.Score < _maxScoreThreshold)
        {
            _velocity.x *= velocityMultiplier;
            _velocity.y *= velocityMultiplier;

            _minScoreThreshold += thresholdRange;
            _maxScoreThreshold += thresholdRange; 
        }
    }
}
