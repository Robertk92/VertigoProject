using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponStats : WeaponStats
{
    [SerializeField]
    private bool _hasAutomaticFiringMode;
    public bool HasAutomaticFiringMode { get { return _hasAutomaticFiringMode; } }
    
}
