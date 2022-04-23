using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectActivator : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Effect>())
        {
            Effect effect = collision.gameObject.GetComponent<Effect>();

            // Particle
            Instantiate(effect.HitParticle, (Vector3)collision.contacts[0].point, Quaternion.identity);

            if(effect.Timer != 0) // to support instant effects
            {
                EffectController.Instance.AddEffect(effect.GetType(), effect.Timer);
                UIController.Instance.UpdateEffectPanel(effect.Sprite, effect.Color, effect.Timer);
            }
            effect.Activate();
        }
    }
}
