using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AmmoClipContext : AttachableContext
{
    [SerializeField]
    private GameObject _projectilePrefab;
    public GameObject ProjectilePrefab { get { return _projectilePrefab; } }

    [SerializeField]
    private int _maxNumProjectiles;
    public int MaxNumProjectiles { get { return _maxNumProjectiles; } }
}
