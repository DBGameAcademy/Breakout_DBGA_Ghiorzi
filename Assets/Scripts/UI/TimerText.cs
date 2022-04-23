using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerText : MonoBehaviour
{
    public float Timer 
    { 
        get=>_timer;
        set
        {
            if (value < 0)
            {
                _timer = 0;
            }
            _currentTime = 0;
            _timer = value;
            _text.text = "";
        }
    }

    private Text _text;
    private float _timer;
    private float _currentTime = 0;

    public void ResetTimer()
    {
        TimerFinished();
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
        _text.text = "";
    }

    private void Update()
    {
        if(_timer > 0)
        {
            if(_currentTime == 0)
            {
                _currentTime = _timer;
            }

            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                _text.text = ""+(int)_currentTime;
            }
            else
            {
                TimerFinished();
            }
        }
    }

    private void TimerFinished()
    {
        _timer = 0;
        _currentTime = 0;
        _text.text = "";
    }

}
