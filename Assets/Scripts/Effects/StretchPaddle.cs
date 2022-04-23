using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchPaddle : Effect
{
    [SerializeField]
    private float stretchValue = 2;

    public override void Activate()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        paddle.Stretch(stretchValue);

        Destroy(this.gameObject);
    }

    public override void Deactivate()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        paddle.ResetStretch();
    }
}
