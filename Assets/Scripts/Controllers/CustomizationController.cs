using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationController : Singleton<CustomizationController>
{
    [SerializeField]
    private List<GameObject> customizations = new List<GameObject>();

    private int _currentIndex;

    private CustomizationLoader _loader;

    public void GoForward()
    {
        if (_loader == null)
            return;

        
        _currentIndex = (_currentIndex + 1) % customizations.Count;
 
        //ShowCustomization(_currentIndex);
        _loader.LoadCustomization();
    }

    public void GoBackward()
    {
        if (_loader == null)
            return;

        if ((_currentIndex - 1) < 0)
        {
            _currentIndex = customizations.Count - 1;
        }
        else
        {
            _currentIndex = ((_currentIndex - 1) % customizations.Count);
        }
       
        // ShowCustomization(_currentIndex);
        _loader.LoadCustomization();
    }

    public GameObject GetCurrentCustomization()
    {
        return customizations[_currentIndex];
    }

    protected override void Awake()
    {
        base.Awake();

        if (customizations.Count == 0)
        {
            throw new System.Exception("There must be at least one customization");
        }

        _currentIndex = 0;
        //ShowCustomization(_currentIndex);

        _loader = FindObjectOfType<CustomizationLoader>();

        DontDestroyOnLoad(this.gameObject);
    }
    /*
    private void ShowCustomization(int index)
    {
        _currentCustomization = Instantiate(customizations[index], paddleObj.transform);
    }*/


}
