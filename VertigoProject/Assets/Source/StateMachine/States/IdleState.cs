using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Activate()
    {
        base.Activate();
    }

    public override void OnInputActionPressed(string action)
    {
        base.OnInputActionPressed(action);

        if (action == PlayerInputKeys.ActionUseItem)
        {
            foreach (KeyValuePair<AttachmentSlotId, Item> kvp in Character.EquipmentManager.EquippedItems)
            {
                if (kvp.Value != null)
                {
                    kvp.Value.Use();
                }
            }
        }
        else if (action == PlayerInputKeys.ActionThrow)
        {
            Item item = Character.EquipmentManager.GetEquipmentInSlot(AttachmentSlotId.RightHand);
            if (item is Throwable)
            {
                Character.StateMachine.TryActivateState(StateId.Throw);
            }
        }
    }
}
