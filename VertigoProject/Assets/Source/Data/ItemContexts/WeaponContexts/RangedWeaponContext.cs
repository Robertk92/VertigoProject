
using UnityEngine;

[CreateAssetMenu]
public class RangedWeaponContext : WeaponContext
{
    [SerializeField]
    private AmmoClipContext _ammoClipContext;
    public AmmoClipContext AmmoClipContext { get { return _ammoClipContext; } }

    [SerializeField]
    private bool _hasAutomaticFiringMode;
    public bool HasAutomaticFiringMode { get { return _hasAutomaticFiringMode; } }

    [SerializeField, Tooltip("Delay (in seconds) between shots")]
    private float _delayBetweenShots = 0.3f;
    public float DelayBetweenShots { get { return _delayBetweenShots; } }

    [SerializeField, Tooltip("Delay (in seconds) before being able to shoot after equipping the ranged weapon to ensure proper posture")]
    private float _postureDelay = 0.3f;
    public float PostureDelay { get { return _postureDelay; } }

    [SerializeField, Tooltip("Time (in seconds) it takes to reload")]
    private float _reloadTime = 3.0f;
    public float ReloadTime { get { return _reloadTime; } }
}
