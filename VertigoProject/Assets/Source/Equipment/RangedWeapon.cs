using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RangedWeaponScriptableObject : ScriptableObject
{
    public RangedWeapon RangedWeapon;
}

[Serializable]
public class RangedWeapon : Weapon
{
    public RangedWeapon(GameObject modelPrefab) : base(modelPrefab)
    {
    }

    public RangedWeapon(RangedWeapon other) : base(other)
    {
    }
}
