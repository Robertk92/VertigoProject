using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterContext _context;
    public CharacterContext Context { get { return _context; } }

    [SerializeField]
    private List<AttachmentSlot> _attachmentSlots;
    public List<AttachmentSlot> AttachmentSlots { get { return _attachmentSlots; } }

    [SerializeField, Tooltip("Default items to add to the character's inventory")]
    private List<ItemCountPair> _defaultItems = new List<ItemCountPair>();
    public List<ItemCountPair> DefaultItems {  get { return _defaultItems; } }

    public StateId ActiveState { get; private set; }
    public EquipmentManager EquipmentManager { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public Animator Animator { get; private set; }
    
    protected virtual void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Debug.AssertFormat(Animator, "Animator not found in Character's children");
        Debug.AssertFormat(Context.StateTransitionRules, "No character state transition rules found");

        // Create state machine and register all states
        StateMachine = new StateMachine(this, StateId.Idle);
        StateMachine.RegisterState<IdleState>(StateId.Idle);
        StateMachine.RegisterState<AimState>(StateId.Aim);
        StateMachine.RegisterState<ReloadState>(StateId.Reload);
        StateMachine.RegisterState<ShootState>(StateId.Shoot);
        
        EquipmentManager = new EquipmentManager(AttachmentSlots);
        EquipmentManager.OnEquipped += OnEquippedHandler;

        foreach (ItemCountPair itemCountPair in _defaultItems)
        {
            for (int i = 0; i < itemCountPair.count; i++)
            {
                EquipmentManager.AddToInventory(itemCountPair.item);
            }
        }
    }

    private void OnEquippedHandler(ItemContext item)
    {
        if(item is RangedWeaponContext)
        {
            StateMachine.TryActivateState(StateId.Aim);
        }
        else
        {
            StateMachine.TryActivateState(StateId.Idle);
        }
    }

    protected virtual void Update()
    {
        
    }
}
