
using System;
using UnityEngine;

[Serializable]
public class AmmoClipStateInfo : ItemStateInfo
{
    public Item Prefab { get; set; }

    private int _projectileCount;
    public int ProjectileCount
    {
        get { return _projectileCount; }
        set
        {
            _projectileCount = value;
            if(value <= 0)
            {
                Depleted = true;
            }
        }
    }
}

public class AmmoClip : Item
{
    [SerializeField]
    private AmmoClipContext _context;
    public AmmoClipContext Context { get { return _context; } }
    
    public AmmoClipStateInfo StateInfo { get; set; }

    private void Awake()
    {
        StateInfo = new AmmoClipStateInfo()
        {
            Prefab = Context.Prefab,
            ProjectileCount = Context.MaxNumProjectiles
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
        AmmoClipStateInfo casted = (AmmoClipStateInfo)stateInfo;
        this.StateInfo.ProjectileCount = casted.ProjectileCount;
    }
}
