using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : Singleton<EffectController> 
{
    private Type _currentEffectType;
    private float _currentEffectTimer= 0;

    private float _currentTime = 0;

    public void AddEffect(Type effectType, float effectTimer)
    {
        if (_currentEffectType != null)
            ResetEffect();
        _currentEffectType = effectType;
        _currentEffectTimer = effectTimer;
        _currentTime = 0;

        Debug.Log("Effect added: " + _currentEffectType + " with timer: " + _currentEffectTimer);
    }

    public void ResetEffect()
    {
        if(_currentEffectType == null)
            return;

        var tempEffect = Activator.CreateInstance(_currentEffectType) as Effect; 
        tempEffect.Deactivate();

        _currentTime = 0;
        _currentEffectTimer = 0;
        _currentEffectType = null;

        Debug.Log("Reset done");
    }

    private void Update()
    {
        if(_currentEffectType == null)
            return ;

        if(_currentTime < _currentEffectTimer)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            // Finished
            ResetEffect();
            Debug.Log("Timer finished");
        }
    }
}
