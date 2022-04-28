using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CustomizationLoader : MonoBehaviour
{
    private GameObject _currentCustomization;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.white;
    }


    private void Start()
    {
        LoadCustomization();
    }

    public void LoadCustomization()
    {
        if(_currentCustomization != null)
            Destroy(_currentCustomization);

        GameObject customization = CustomizationController.Instance.GetCurrentCustomization();
        UpdateColor(CustomizationController.Instance.GetCurrentColor());

        _currentCustomization = Instantiate(customization, this.transform);
    }

    public void UpdateColor(Color color)
    {
        if (color == null || _spriteRenderer == null)
            return;

        _spriteRenderer.color = color;
    }
}
