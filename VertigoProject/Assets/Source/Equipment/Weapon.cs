using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon : Item
{
    
    public float BaseDamage;

    public Weapon(GameObject modelPrefab) : base(modelPrefab)
    {
    }

    public Weapon(Weapon other) : base(other)
    {
    }
}
