using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State
{
    private RangedWeapon _rangedWeapon;

    public override void Activate()
    {
        base.Activate();
        Character.EquipmentManager.LockSlot(AttachmentSlotId.RightHand);
        Character.Animator.SetInteger("State", (int)Id);
        _rangedWeapon = (RangedWeapon)Character.EquipmentManager.GetEquipmentInSlot(AttachmentSlotId.RightHand);
        if(_rangedWeapon == null)
        {
            StateMachine.TryActivateState(StateId.Idle);
        }
        Shoot();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Character.EquipmentManager.UnlockSlot(AttachmentSlotId.RightHand);
    }

    private void Shoot()
    {
        if (_rangedWeapon.AmmoClip == null)
        {
            StateMachine.TryActivateState(StateId.Reload);
            Debug.Log("No clip");
            return;
        }
        else if (_rangedWeapon.AmmoClip.ProjectileCount == 0)
        {
            StateMachine.TryActivateState(StateId.Reload);
            Debug.Log("No ammo");
            return;
        }

        GameObject projectile = GameObject.Instantiate(_rangedWeapon.AmmoClip.Context.ProjectilePrefab);
        projectile.transform.position = _rangedWeapon.ProjectileSpawn.transform.position;
        projectile.transform.rotation = _rangedWeapon.ProjectileSpawn.transform.rotation;
        _rangedWeapon.AmmoClip.ProjectileCount--;
        
        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
        rigidbody.AddForce(projectile.transform.forward * 1000.0f);

        if (_rangedWeapon.AmmoClip.ProjectileCount == 0)
        {
            StateMachine.TryActivateState(StateId.Reload);
        }
        else
        {
            StateMachine.TryActivateState(StateId.Aim);
        }
    }
}
