using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public MeleeWeapon(GameObject modelPrefab) : base(modelPrefab)
    {
    }

    public MeleeWeapon(MeleeWeapon other) : base(other)
    {
    }
}
