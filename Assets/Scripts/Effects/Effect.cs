using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Effect : MonoBehaviour, IActivable
{
    public GameObject HitParticle { get => hitParticle; }
    public float Timer { get => timer; }
    public Sprite Sprite { get => spriteRenderer.sprite; }
    public Color Color { get => spriteRenderer.color; }

    [SerializeField]
    protected float fallSpeed;
    [SerializeField]
    protected float timer;
    [SerializeField]
    protected GameObject hitParticle;

    protected SpriteRenderer spriteRenderer;

    public abstract void Activate();
    public abstract void Deactivate();

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void OnEnable()
    {
        GameController.OnGameReset += DestroyEffect;
    }

    protected void OnDisable()
    {
        GameController.OnGameReset -= DestroyEffect;
    }

    protected void Update()
    {
        // Fall
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Destroy if didn't catch
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    protected void DestroyEffect()
    {
        Destroy(gameObject);
    }

}
