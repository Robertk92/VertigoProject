﻿using System.Collections;
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
        _canShoot = false;
        StartCoroutine(DelayNextShot(_rangedWeapon.Context.PostureDelay));
    }
    
    public override void OnInputActionHold(string action)
    {
        base.OnInputActionHold(action);

        // Shoot in automatic firing mode
        if(_rangedWeapon.StateInfo.FireMode == RangedWeaponFireMode.Automatic)
        {
            if (action == PlayerInputKeys.ActionShoot && _canShoot)
            {
                StateMachine.TryActivateState(StateId.Shoot);
                StartCoroutine(DelayNextShot(_rangedWeapon.Context.DelayBetweenShots));
            }
        }
    }

    public override void OnInputActionPressed(string action)
    {
        base.OnInputActionPressed(action);

        // Shoot in single firing mode 
        if (_rangedWeapon.StateInfo.FireMode == RangedWeaponFireMode.Single)
        {
            if (action == PlayerInputKeys.ActionShoot && _canShoot)
            {
                StateMachine.TryActivateState(StateId.Shoot);
                StartCoroutine(DelayNextShot(_rangedWeapon.Context.DelayBetweenShots));
            }
        }

        // Single/Automatic firing mode toggle
        if (action == PlayerInputKeys.ActionToggleFiringMode)
        {
            if (_rangedWeapon.StateInfo.FireMode == RangedWeaponFireMode.Single)
            {
                _rangedWeapon.StateInfo.FireMode = RangedWeaponFireMode.Automatic;
            }
            else
            {
                _rangedWeapon.StateInfo.FireMode = RangedWeaponFireMode.Single;
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
