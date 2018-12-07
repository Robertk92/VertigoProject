using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Character
{
    protected override void Awake()
    {
        base.Awake();
        foreach (Item item in Game.Instance.Database.Items)
        {
            EquipmentManager.AddToInventory(item);
        }
        
        Debug.Log(((RangedWeapon)EquipmentManager.Inventory.First()).BaseDamage);
    }
}
