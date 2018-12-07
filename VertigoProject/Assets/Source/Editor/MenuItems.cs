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

    [MenuItem("Assets/Create/Item/Ranged Weapon")]
    private static void CreateRangedWeapon()
    {
        ScriptableObjectUtility.CreateAsset<RangedWeaponScriptableObject>();
    }

    [MenuItem("Assets/Create/Data/Database")]
    private static void CreateDatabase()
    {
        ScriptableObjectUtility.CreateAsset<Database>();
    }
}
