using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteParentFollower : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer parentSpriteRenderer;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.size = new Vector2(parentSpriteRenderer.size.x, parentSpriteRenderer.size.y);
    }
}
