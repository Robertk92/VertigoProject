using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Weapon
{
    public Throwable(GameObject modelPrefab) : base(modelPrefab)
    {
    }

    public Throwable(Throwable other) : base(other)
    {
    }
}
