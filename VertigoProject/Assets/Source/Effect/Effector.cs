using System;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour
{
    [SerializeField]
    private List<EffectsEventPair> _effects = new List<EffectsEventPair>();

    private void OnCollisionEnter(Collision collision)
    {
        ApplyEffects(EffectorEvent.OnCollisionEnter);
    }

    private void ApplyEffects(EffectorEvent effectorEvent)
    {
        foreach (EffectsEventPair pair in _effects)
        {
            if (pair.effectorEvent == effectorEvent)
            {
                foreach (Effect effect in pair.effects)
                {
                    effect.Apply(gameObject);
                }
            }
        }
    }
}
