
using UnityEngine;

[CreateAssetMenu]
public class DealDamageEffect : Effect
{
    [SerializeField]
    private float _damageAmount;

    public override void Apply(GameObject target)
    {
        //CombatStats stats = target.GetComponentInChildren<CombatStats>();
        //stats.TakeDamage(_damageAmount);
    }
}
