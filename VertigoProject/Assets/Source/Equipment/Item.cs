using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Item 
{
    [SerializeField]
    private GameObject _modelPrefab;
    public GameObject ModelPrefab { get { return _modelPrefab; } }

    public Item(GameObject modelPrefab)
    {
        _modelPrefab = modelPrefab;
    }

    public Item(Item other)
        : this(other.ModelPrefab)
    {

    }
    
}
