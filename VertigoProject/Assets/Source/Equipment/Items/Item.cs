
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStateInfo
{
    public bool Depleted { get; set; }
}

public abstract class Item : MonoBehaviour
{
    public abstract ItemContext GetContext();
    public abstract ItemStateInfo GetStateInfo();
    public abstract void InitStateInfo(ItemStateInfo stateInfo);

    public virtual bool Use() { return false;  }
}
