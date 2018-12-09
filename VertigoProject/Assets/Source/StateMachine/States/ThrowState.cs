using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThrowState : State
{
    private Throwable _throwable;

    public override void Activate()
    {
        base.Activate();
        MultiStateOptions.canEquipItems = false;

        _throwable = (Throwable)Character.EquipmentManager.GetEquipmentInSlot(AttachmentSlotId.RightHand);
        if (_throwable == null)
        {
            StateMachine.TryActivateState(StateId.Idle);
        }

        Character.Animator.SetInteger("State", (int)Id);
        
        Character.AnimationEventHandler.OnAnimEventReleaseThrowable += OnRelease;
        Character.AnimationEventHandler.OnAnimEventThrowEnded += OnThrowEnded;
    }

    private void OnThrowEnded()
    {
        Character.StateMachine.TryActivateState(StateId.Idle);
        Character.AnimationEventHandler.OnAnimEventThrowEnded -= OnThrowEnded;
    }

    private void OnRelease()
    {
        Character.EquipmentManager.UnEquip(AttachmentSlotId.RightHand);
        _throwable.Rigidbody.isKinematic = false;
        Transform rightHandTransform = Character.AttachmentSlots.Single(x => x.SlotId == AttachmentSlotId.RightHand).BoneTransform;
        _throwable.Rigidbody.AddForce(rightHandTransform.forward * _throwable.Context.ThrowForce);
        Character.AnimationEventHandler.OnAnimEventReleaseThrowable -= OnRelease;
    }
}
