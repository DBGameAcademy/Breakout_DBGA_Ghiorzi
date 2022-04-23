using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingHand : Effect
{
    public override void Activate()
    {
        AISpawnController.Instance.SpawnPaddle();

        Destroy(gameObject);
    }

    public override void Deactivate()
    {
        AISpawnController.Instance.DestroyPaddle();
    }
}
