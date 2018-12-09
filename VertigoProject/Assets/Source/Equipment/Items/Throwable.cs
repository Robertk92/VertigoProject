
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : Weapon
{
    [SerializeField]
    private ThrowableContext _context;
    public ThrowableContext Context { get { return _context; } }

    public ItemStateInfo StateInfo { get; set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StateInfo = new ItemStateInfo()
        {
        };
    }

    public override ItemContext GetContext()
    {
        return Context;
    }

    public override ItemStateInfo GetStateInfo()
    {
        return StateInfo;
    }

    public override void InitStateInfo(ItemStateInfo stateInfo)
    {
        this.StateInfo.Depleted = stateInfo.Depleted;
    }
}
