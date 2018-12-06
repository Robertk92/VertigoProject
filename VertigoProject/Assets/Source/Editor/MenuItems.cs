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

    [MenuItem("Assets/Create/Equipment/Attachable")]
    private static void CreateAttachable()
    {
        ScriptableObjectUtility.CreateAsset<Item>();
    }

    [MenuItem("Assets/Create/Equipment/Weapon/Melee Weapon")]
    private static void CreateMeleeWeapon()
    {
        ScriptableObjectUtility.CreateAsset<MeleeWeapon>();
    }

    [MenuItem("Assets/Create/Equipment/Weapon/Ranged Weapon")]
    private static void CreateRangedWeapon()
    {
        ScriptableObjectUtility.CreateAsset<RangedWeapon>();
    }

    [MenuItem("Assets/Create/Equipment/Weapon/Throwable")]
    private static void CreateThrowable()
    {
        ScriptableObjectUtility.CreateAsset<Throwable>();
    }
}
