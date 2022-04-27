using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationController : Singleton<CustomizationController>
{
    [SerializeField]
    private GameObject paddleObj;

    [SerializeField]
    private List<GameObject> customizations = new List<GameObject>();

    private int _currentIndex;
    private GameObject _currentCustomization;

    public void GoForward()
    {
        Destroy(_currentCustomization);
        _currentIndex = (_currentIndex + 1) % customizations.Count;
        ShowCustomization(_currentIndex);
    }

    public void GoBackward()
    {
        Destroy(_currentCustomization);
        if ((_currentIndex - 1) < 0)
        {
            _currentIndex = customizations.Count - 1;
        }
        else
        {
            _currentIndex = ((_currentIndex - 1) % customizations.Count);
        }
        ShowCustomization(_currentIndex);
    }

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Awake Called");
        if (customizations.Count == 0)
        {
            throw new System.Exception("There must be at least one customization");
        }

        _currentIndex = 0;
        ShowCustomization(_currentIndex);
        DontDestroyOnLoad(this.gameObject);
    }

    private void ShowCustomization(int index)
    {
        _currentCustomization = Instantiate(customizations[index], paddleObj.transform);
    }


}
