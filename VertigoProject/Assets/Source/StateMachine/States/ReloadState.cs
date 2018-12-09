using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : State 
{
    private RangedWeapon _rangedWeapon;

    public override void Activate()
    {
        base.Activate();

        Character.EquipmentManager.LockSlot(AttachmentSlotId.RightHand);
        _rangedWeapon = (RangedWeapon)Character.EquipmentManager.GetEquipmentInSlot(AttachmentSlotId.RightHand);
        if(_rangedWeapon == null)
        {
            StateMachine.TryActivateState(StateId.Idle);
            return;
        }

        AmmoClipContext nextAmmoClip = GetNextClipFromInventory();
        if(_rangedWeapon.AmmoClip == null && nextAmmoClip == null)
        {
            StateMachine.TryActivateState(StateId.Idle);
            return;
        }

        if (_rangedWeapon.AmmoClip != null)
        {
            if (_rangedWeapon.AmmoClip.ProjectileCount == 0 && nextAmmoClip == null)
            {
                StateMachine.TryActivateState(StateId.Idle);
                return;
            }
        }

        Character.Animator.SetInteger("State", (int)Id);
        float reloadTime = Character.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        StartCoroutine(Reload(reloadTime));
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Character.EquipmentManager.UnlockSlot(AttachmentSlotId.RightHand);
    }

    private AmmoClipContext GetNextClipFromInventory()
    {
        AmmoClipContext ammoClipContext = null;
        foreach (ItemContext itemContext in Character.EquipmentManager.Inventory)
        {
            if (_rangedWeapon.Context.AmmoClipContext == itemContext)
            {
                ammoClipContext = (AmmoClipContext)itemContext;
                break;
            }
        }
        return ammoClipContext;
    }

    private IEnumerator Reload(float time)
    {
        AmmoClipContext ammoClipContext = GetNextClipFromInventory();    
        
        if(ammoClipContext == null)
        {
            // No ammo clips in inventory, no need to continue reloading
            StateMachine.TryActivateState(StateId.Aim);
        }
        
        AmmoClip spawnedAmmoClip = (AmmoClip)Character.EquipmentManager.Equip(AttachmentSlotId.LeftHand, ammoClipContext);
        
        yield return new WaitForSeconds(time);
        spawnedAmmoClip.transform.SetParent(_rangedWeapon.AmmoClipParent);
        spawnedAmmoClip.transform.localPosition = Vector3.zero;
        spawnedAmmoClip.transform.localRotation = Quaternion.identity;
        _rangedWeapon.AmmoClip = spawnedAmmoClip;

        StateMachine.TryActivateState(StateId.Aim);
    }
    
}
