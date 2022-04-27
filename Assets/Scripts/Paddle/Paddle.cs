using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float AcceleratedSpeed { get => acceleratedSpeed; set => acceleratedSpeed = value; }

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleratedSpeed;

    [SerializeField]
    private float defaultStretchValue = 1;
    [SerializeField]
    private Vector3 paddleResetPosition;

    private float _speed;
    private float _defaultMoveSpeed;
    private float _defaultAcceleratedSpeed;

    private BoxCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private PaddleCollision _paddleCollision;

    private void Start()
    {
        _speed = moveSpeed;
        _defaultAcceleratedSpeed = acceleratedSpeed;
        _defaultMoveSpeed = moveSpeed;

        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _paddleCollision = GetComponent<PaddleCollision>();
    }

    public void Move(Vector2 direction)
    {
        if (direction.Equals(Vector2.left) && _paddleCollision.IsCollidingLeft)
            return;
        if (direction.Equals(Vector2.right) && _paddleCollision.IsCollidingRight)
            return;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void Accelerate()
    {
        _speed = acceleratedSpeed;
    }

    public void Deaccelerate()
    {
        _speed = moveSpeed; 
    }

    public void Stretch(float value)
    {
        if (value <= 0)
            return;

        StretchCustomizations(value);

        // Stretch Paddle
        _collider.size = new Vector2(value, _collider.size.y);
        _spriteRenderer.size = new Vector2(value, _spriteRenderer.size.y);
    }

    public void ResetStretch()
    {
        Stretch(defaultStretchValue);
    }

    public void ResetPosition()
    {
        transform.position = paddleResetPosition;
    }

    public void ResetSpeeds()
    {
        moveSpeed = _defaultMoveSpeed;
        acceleratedSpeed = _defaultAcceleratedSpeed;
    }

    private void StretchCustomizations(float value)
    {
        // Stretch Customizations
        Customization[] customs = GetComponentsInChildren<Customization>();
        
        if (customs.Length == 0)
            return;

        foreach (Customization custom in customs)
        {
            custom.Stretch((value - _spriteRenderer.size.x) / 2.0f);
        }
    }
}
