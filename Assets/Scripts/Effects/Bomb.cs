using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Effect
{
    public override void Activate()
    {
        GameController.Instance.LoseLife();

        Destroy(gameObject);
    }

    public override void Deactivate()
    {
        // Nothing
    }
}
