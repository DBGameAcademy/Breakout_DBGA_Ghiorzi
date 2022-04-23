using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleVelocityChanger : Effect
{
    [SerializeField]
    private float newVelocity;
    [SerializeField]
    private float newAcceleratedSpeed;

    public override void Activate()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        paddle.MoveSpeed = newVelocity;
        paddle.AcceleratedSpeed = newAcceleratedSpeed;

        Destroy(gameObject);
    }

    public override void Deactivate()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        paddle.ResetSpeeds();
    }
}
