using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedWeapon : Weapon
{
    public enum FiringMode
    {
        Single,
        Automatic
    }

    [SerializeField]
    private RangedWeaponContext _context;
    public RangedWeaponContext Context { get { return _context; } }

    [SerializeField]
    private Transform _projectileSpawn;
    public Transform ProjectileSpawn { get { return _projectileSpawn; } }

    [SerializeField]
    private Transform _ammoClipParent;
    public Transform AmmoClipParent { get { return _ammoClipParent; } }

    public AmmoClip AmmoClip { get; set; }
    public FiringMode FireMode { get; set; }

    public override ItemContext GetItemContext()
    {
        return Context;
    }
}
