using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterStateTransitionRules _stateTransitionRules;

    [SerializeField]
    private List<AttachmentSlot> _attachmentSlots;

    [SerializeField, Tooltip("Default items to add to the character's inventory")]
    private List<Item> _defaultItems = new List<Item>();

    public CharacterState ActiveState { get; private set; }
    public EquipmentManager EquipmentManager { get; private set; }
    
    private Animator _animator;

    protected virtual void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        Debug.AssertFormat(_animator, "Animator not found in Character's children");
        Debug.AssertFormat(_stateTransitionRules, "No character state transition rules found");

        EquipmentManager = new EquipmentManager(_attachmentSlots);
        EquipmentManager.OnEquipped += OnEquippedHandler;
        foreach (Item item in _defaultItems)
        {
            EquipmentManager.AddToInventory(item);
        }
    }

    private void OnEquippedHandler(Item item)
    {
        if(item is RangedWeaponStats)
        {
            TryActivateState(CharacterState.Aim);
        }
    }

    protected virtual void Update()
    {

    }

    /// <summary>
    /// Attempts to activate the given state using the character state transition rules
    /// </summary>
    /// <param name="state">The state to activate</param>
    /// <returns>Wheter or not the stata transition is allowed</returns>
    public bool TryActivateState(CharacterState state)
    {
        if(CanTransitionTo(state))
        {
            ActiveState = state;
            _animator.SetInteger("State", (int)state);
            return true;
        }
        return false;
    }
    
    private bool CanTransitionTo(CharacterState state)
    {
        CharacterStateTransitionRule rule = _stateTransitionRules.Rules.FirstOrDefault(x => x.state == ActiveState);

        if(rule == null)
        {
            return true;
        }

        return rule.allowedStates.Contains(state);
    }
}
