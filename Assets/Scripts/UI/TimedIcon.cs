using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedIcon : MonoBehaviour
{
    [SerializeField]
    private TimerText timerText;

    private Image _image;


    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if(timerText.Timer > 0)
        {
            _image.enabled = true;
        }
        else
        {
            _image.enabled = false;
        }
    }


}
