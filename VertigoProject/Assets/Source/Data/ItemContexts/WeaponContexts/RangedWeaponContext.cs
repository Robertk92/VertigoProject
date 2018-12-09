using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RangedWeaponContext : WeaponContext
{
    [SerializeField]
    private AmmoClipContext _ammoClipContext;
    public AmmoClipContext AmmoClipContext { get { return _ammoClipContext; } }

    [SerializeField]
    private bool _hasAutomaticFiringMode;
    public bool HasAutomaticFiringMode { get { return _hasAutomaticFiringMode; } }

    [SerializeField, Tooltip("Minimum delay (in seconds) between shots")]
    private float _minDelayBetweenShots = 0.3f;
    public float MinDelayBetweenShots { get { return _minDelayBetweenShots; } }

    [SerializeField, Tooltip("The time (in seconds) it takes to reload the ranged weapon")]
    private float _reloadTime;
    public float ReloadTime { get { return _reloadTime; } }
}
