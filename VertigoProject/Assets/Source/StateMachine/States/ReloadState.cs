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
            StateMachine.TryActivateState(StateId.Aim);
            return;
        }

        InventoryItem nextAmmoClipInventoryItem = GetNextClipFromInventory();
        if(nextAmmoClipInventoryItem == null)
        {
            StateMachine.TryActivateState(StateId.Aim);
            return;
        }

        if (_rangedWeapon.StateInfo.AmmoClipStateInfo != null)
        {
            if (_rangedWeapon.StateInfo.AmmoClipStateInfo.ProjectileCount == 0 && nextAmmoClipInventoryItem == null)
            {
                StateMachine.TryActivateState(StateId.Aim);
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

    private InventoryItem GetNextClipFromInventory()
    {
        InventoryItem ammoClipInventoryItem = null;
        foreach (InventoryItem inventoryItem in Character.EquipmentManager.Inventory)
        {
            if (_rangedWeapon.Context.AmmoClipContext == inventoryItem.context)
            {
                ammoClipInventoryItem = inventoryItem;
                break;
            }
        }
        return ammoClipInventoryItem;
    }

    private IEnumerator Reload(float time)
    {
        InventoryItem ammoClipInventoryItem = GetNextClipFromInventory();    
        
        if(_rangedWeapon.AmmoClip != null)
        {
            GameObject.Destroy(_rangedWeapon.AmmoClip.gameObject);
            _rangedWeapon.AmmoClip = null;
        }

        AmmoClip spawnedAmmoClip = (AmmoClip)Character.EquipmentManager.Equip(AttachmentSlotId.LeftHand, ammoClipInventoryItem);
        
        yield return new WaitForSeconds(time);
        spawnedAmmoClip.transform.SetParent(_rangedWeapon.AmmoClipParent);
        spawnedAmmoClip.transform.localPosition = Vector3.zero;
        spawnedAmmoClip.transform.localRotation = Quaternion.identity;
        _rangedWeapon.StateInfo.AmmoClipStateInfo = spawnedAmmoClip.StateInfo;

        StateMachine.TryActivateState(StateId.Aim);
    }
    
}
