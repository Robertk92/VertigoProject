using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedWeapon : MonoBehaviour
{
    [SerializeField]
    private RangedWeaponStats _stats;
    public RangedWeaponStats Stats { get { return _stats; } }

    [SerializeField]
    private AmmoClip _ammoClip;
    public AmmoClip AmmoClip { get { return _ammoClip; } }
    
    [SerializeField]
    private Transform _projectileSpawn;
    public Transform ProjectileSpawn { get { return _projectileSpawn; } }

    private void Update()
    {
        
        // pew pew
    }
    //
}
