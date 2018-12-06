using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField]
    private GameObject _modelPrefab;
    public GameObject ModelPrefab { get { return _modelPrefab; } }
}
