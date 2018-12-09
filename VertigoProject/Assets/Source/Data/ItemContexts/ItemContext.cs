using System;
using UnityEngine;

public abstract class ItemContext : ScriptableObject
{
    [SerializeField]
    private Item _prefab;
    public Item Prefab { get { return _prefab; } }
    
}
