using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private float _currentSpeed;

    private void Awake()
    {
        _currentSpeed = rotationSpeed;
    }

    private void Update()
    {
        if(Time.deltaTime == 0)
            StopRotation();
        else
            StartRotation();

        transform.Rotate(0, 0, _currentSpeed);
    }

    public void StopRotation()
    {
        _currentSpeed = 0;
    }

    public void StartRotation()
    {
        _currentSpeed = rotationSpeed;
    }
}
