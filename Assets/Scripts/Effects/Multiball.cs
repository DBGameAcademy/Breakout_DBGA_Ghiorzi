using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiball : Effect
{
    public override void Activate()
    {
        MultiballController.Instance.AddBall();
        Destroy(gameObject);
    }

    public override void Deactivate()
    {
        // Nothing
    }
}
