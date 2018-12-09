
using UnityEngine;

public abstract class WeaponContext : AttachableContext
{
    [SerializeField]
    private float _baseDamage;
    public float BaseDamage { get { return _baseDamage; } }
}
