using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ThrowableContext : WeaponContext
{
    [SerializeField]
    private float _throwForce;
    public float ThrowForce { get { return _throwForce; } }
}
