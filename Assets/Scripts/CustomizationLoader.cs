using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationLoader : MonoBehaviour
{
    private GameObject _currentCustomization;
    private void Start()
    {
        LoadCustomization();
    }

    public void LoadCustomization()
    {
        if(_currentCustomization != null)
            Destroy(_currentCustomization);

        GameObject customization = CustomizationController.Instance.GetCurrentCustomization();

        _currentCustomization = Instantiate(customization, this.transform);
    }
}
