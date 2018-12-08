using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class MenuItems
{
    [MenuItem("Assets/Create/CharacterStateTransitionRules")]
    private static void CreateStateTransitionRules()
    {
        ScriptableObjectUtility.CreateAsset<CharacterStateTransitionRules>();
    }

    [MenuItem("Assets/Create/Item/Ranged Weapon Stats")]
    private static void CreateRangedWeaponStats()
    {
        ScriptableObjectUtility.CreateAsset<RangedWeaponStats>();
    }
    
}
