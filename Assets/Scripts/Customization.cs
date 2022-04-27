using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    public void Stretch(float value)
    {
        if (transform.localPosition.x == 0.0f)
            return;

        if (transform.localPosition.x < 0.0f)
            value *= -1.0f;

        transform.localPosition = new Vector3(transform.localPosition.x + value, transform.localPosition.y);
    }
}
