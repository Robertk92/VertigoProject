using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : State
{
    private RangedWeapon _rangedWeapon;
    private bool _canShoot;

    public override void Activate()
    {
        base.Activate();
        _rangedWeapon = (RangedWeapon)Character.EquipmentManager.GetEquipmentInSlot(AttachmentSlotId.RightHand);
        if (_rangedWeapon == null)
        {
            StateMachine.TryActivateState(StateId.Idle);
        }
        Character.Animator.SetInteger("State", (int)Id);
        _canShoot = true;
    }

    public override void OnInputActionHold(string action)
    {
        base.OnInputActionHold(action);

        // Shoot in automatic firing mode
        if(_rangedWeapon.FireMode == RangedWeapon.FiringMode.Automatic)
        {
            if (action == PlayerInputKeys.ActionShoot && _canShoot)
            {
                StateMachine.TryActivateState(StateId.Shoot);
                StartCoroutine(DelayNextShot(_rangedWeapon.Context.MinDelayBetweenShots));
            }
        }
    }

    public override void OnInputActionPressed(string action)
    {
        base.OnInputActionPressed(action);

        // Shoot in single firing mode 
        if (_rangedWeapon.FireMode == RangedWeapon.FiringMode.Single)
        {
            if (action == PlayerInputKeys.ActionShoot && _canShoot)
            {
                StateMachine.TryActivateState(StateId.Shoot);
                StartCoroutine(DelayNextShot(_rangedWeapon.Context.MinDelayBetweenShots));
            }
        }

        // Single/Automatic firing mode toggle
        if (action == PlayerInputKeys.ActionToggleFiringMode)
        {
            if (_rangedWeapon.FireMode == RangedWeapon.FiringMode.Single)
            {
                _rangedWeapon.FireMode = RangedWeapon.FiringMode.Automatic;
            }
            else
            {
                _rangedWeapon.FireMode = RangedWeapon.FiringMode.Single;
            }
        }
    }

    private IEnumerator DelayNextShot(float time)
    {
        _canShoot = false;
        yield return new WaitForSeconds(time);
        _canShoot = true;
    }

}
