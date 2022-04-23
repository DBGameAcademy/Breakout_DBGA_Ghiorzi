using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamageChanger : Effect
{
    [SerializeField]
    private int newBallDamage = 2;

    public override void Activate()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach(Ball ball in balls)
            ball.SetBallDamage(newBallDamage);

        Destroy(gameObject);
    }

    public override void Deactivate()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
            ball.ResetBallDamage();
    }
}
