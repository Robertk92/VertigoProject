using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DestroyEffect : Effect
{
    public override void Apply(GameObject target)
    {
        GameObject.Destroy(target);
    }
}
