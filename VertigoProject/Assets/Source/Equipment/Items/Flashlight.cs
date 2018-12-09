using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Item
{
    [SerializeField]
    private ItemContext _context;
    public ItemContext Context { get { return _context; } }

    public override ItemContext GetItemContext()
    {
        return Context;    
    }
}
