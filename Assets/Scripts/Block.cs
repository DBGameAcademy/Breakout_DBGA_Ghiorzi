using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public int Hits
    {
        get { return hits; }
        set
        {
            if (value <= 0)
                Debug.LogError("Block's Hits cannot be <= 0");
            else
                hits = value;
        }
    }

    public GameObject Effect
    {
        get => dropEffect;
        set { dropEffect = value; }
    }

    public int ScoreValue { get; set; }
    [SerializeField]
    private AudioClip onBreakAudio;

    [SerializeField]
    private int hits;
    [SerializeField]
    private GameObject dropEffect;
    [SerializeField]
    private GameObject explosionPrefab;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        if (hits <= 0)
            Debug.LogError("Block's Hits cannot be <= 0");

        ScoreValue = 100 * hits;
    }

    private void Update()
    {
        UpdateColor();
    }

    public void OnHit(int damage)
    {
        _animator.SetTrigger("Hit");

        hits -= damage;

        if (hits <= 0) // OnDie
        {
            if (dropEffect != null)
            {
                Instantiate(dropEffect, transform.position, Quaternion.identity);
            }

            GameController.Instance.AddScore(ScoreValue);
            AudioController.Instance.PlayClip(onBreakAudio);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void UpdateColor()
    {
        if(hits == 1)
        {
            _spriteRenderer.color = Color.green;
        }
        else if(hits == 2)
        {
            _spriteRenderer.color = Color.blue;
        }
        else // >= 3
        {
            _spriteRenderer.color = Color.red;
        }
    }
}
