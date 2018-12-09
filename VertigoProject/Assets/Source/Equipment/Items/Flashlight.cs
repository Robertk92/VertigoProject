using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightStateInfo : ItemStateInfo
{
    public bool IsLightOn { get; set; }
}

public class Flashlight : Item
{
    [SerializeField]
    private ItemContext _context;
    public ItemContext Context { get { return _context; } }

    [SerializeField]
    private Light _light;

    public FlashlightStateInfo StateInfo { get; set; }

    private void Awake()
    {
        StateInfo = new FlashlightStateInfo()
        {
            IsLightOn = true
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
        FlashlightStateInfo casted = (FlashlightStateInfo)stateInfo;
        this.StateInfo.IsLightOn = casted.IsLightOn;
        RefreshLight();
    }

    public override bool Use()
    {
        StateInfo.IsLightOn = !StateInfo.IsLightOn;
        RefreshLight();
        return false;
    }

    private void RefreshLight()
    {
        _light.enabled = StateInfo.IsLightOn;
    }
}
