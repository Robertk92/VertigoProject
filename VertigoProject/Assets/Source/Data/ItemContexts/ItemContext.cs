using System;
using UnityEngine;

/**
 * An ItemContext is the shared state of an item (all items that share the context share the same values)
 * Unlike ItemStateInfo which serves as a container for all non-shared variables
 * This distinction is usefull in order to keep things as data driven as possible but at the same time have a way of
 * storing per-instance data when destroying the actual game object (when adding something to the non-physical inventory)
 */
public abstract class ItemContext : ScriptableObject
{
    [SerializeField]
    private Item _prefab;
    public Item Prefab { get { return _prefab; } }
    
}
