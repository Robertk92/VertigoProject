using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemFactory
{
    public static GameObject SpawnGameObjectFromItem(Item item)
    {
        Debug.AssertFormat(item.Prefab, string.Format("No prefab set for item '{0}'", item.name));
        return GameObject.Instantiate(item.Prefab);
    }
}
