using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RangedWeaponFireMode
{
    Single,
    Automatic
}

[System.Serializable]
public class RangedWeaponStateInfo : ItemStateInfo
{
    public AmmoClipStateInfo AmmoClipStateInfo { get; set; }
    public RangedWeaponFireMode FireMode { get; set; }
}

public class RangedWeapon : Weapon
{
    [SerializeField]
    private RangedWeaponContext _context;
    public RangedWeaponContext Context { get { return _context; } }

    [SerializeField]
    private Transform _projectileSpawn;
    public Transform ProjectileSpawn { get { return _projectileSpawn; } }

    [SerializeField]
    private Transform _ammoClipParent;
    public Transform AmmoClipParent { get { return _ammoClipParent; } }
    
    public RangedWeaponStateInfo StateInfo { get; set; }
    public AmmoClip AmmoClip { get; set; }

    private void Awake()
    {
        StateInfo = new RangedWeaponStateInfo()
        {
            AmmoClipStateInfo = default(AmmoClipStateInfo),
            FireMode = RangedWeaponFireMode.Single
        };
    }

    public override ItemContext GetContext()
    {
        return Context;
    }

    public override ItemStateInfo GetStateInfo()
    {
        return StateInfo;
    }

    public override void InitStateInfo(ItemStateInfo stateInfo)
    {
        RangedWeaponStateInfo casted = (RangedWeaponStateInfo)stateInfo;
        this.StateInfo.FireMode = casted.FireMode;
        this.StateInfo.AmmoClipStateInfo = casted.AmmoClipStateInfo;

        if (this.StateInfo.AmmoClipStateInfo != null)
        {
            if (StateInfo.AmmoClipStateInfo.ProjectileCount > 0)
            {
                AmmoClip = (AmmoClip)GameObject.Instantiate(StateInfo.AmmoClipStateInfo.Prefab);
                AmmoClip.transform.SetParent(AmmoClipParent);
                AmmoClip.transform.localPosition = Vector3.zero;
                AmmoClip.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
