
using UnityEngine;

public class AmmoClip : Item
{
    [SerializeField]
    private AmmoClipContext _context;
    public AmmoClipContext Context { get { return _context; } }

    public int ProjectileCount { get; set; }

    public override ItemContext GetItemContext()
    {
        return Context;
    }

    private void Awake()
    {
        ProjectileCount = Context.MaxNumProjectiles;
    }
}
