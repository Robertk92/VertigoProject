using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : ScriptableObject
{
    [SerializeField] private List<Item> _items;
    public IEnumerable<Item> Items { get { return _items; } }
}
