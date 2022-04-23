using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestructor : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 1.5f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
    }
}
