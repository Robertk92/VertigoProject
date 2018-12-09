
using System.Collections;
using System.Collections.Generic;

public class MultiStateOptions
{
    public bool canEquipItems;
}

/**
 * Base class for every state
 * Contains some variables and functions that are useful in most states
 */
public abstract class State
{
    public Character Character { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public StateId Id { get; private set; }

    public MultiStateOptions MultiStateOptions { get; private set; }

    private List<IEnumerator> _stateCoroutines = new List<IEnumerator>();

    public void Register(StateId id, StateMachine stateMachine, Character character)
    {
        this.Id = id;
        this.Character = character;
        this.StateMachine = stateMachine;

        MultiStateOptions = new MultiStateOptions()
        {
            canEquipItems = true
        };
    }

    protected void StartCoroutine(IEnumerator coroutine)
    {
        _stateCoroutines.Add(coroutine);
        Character.StartCoroutine(coroutine);
    }

    public virtual void OnInputActionHold(string action)
    {

    }

    public virtual void OnInputActionPressed(string action)
    {
        if (MultiStateOptions.canEquipItems)
        {
            if (action == PlayerInputKeys.ActionEquip1)
            {
                Character.EquipmentManager.Equip(
                    AttachmentSlotId.RightHand,
                    Character.EquipmentManager.GetInventoryItemByName("M4A1"));
            }
            else if (action == PlayerInputKeys.ActionEquip2)
            {
                Character.EquipmentManager.Equip(
                    AttachmentSlotId.RightHand,
                    Character.EquipmentManager.GetInventoryItemByName("Flashlight"));
            }
            else if (action == PlayerInputKeys.ActionEquip3)
            {
                Character.EquipmentManager.Equip(
                    AttachmentSlotId.RightHand,
                    Character.EquipmentManager.GetInventoryItemByName("Rock"));
            }
            else if (action == PlayerInputKeys.ActionEquip4)
            {
                
            }
        }
    }

    public virtual void Init()
    {
    }

    public virtual void Activate()
    {
    }

    public virtual void Deactivate()
    {
        // Stop all state specific coroutines
        foreach (IEnumerator coroutine in _stateCoroutines)
        {
            Character.StopCoroutine(coroutine);
        }
    }
}
