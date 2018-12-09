﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Player _possessedPlayer;

	public void Possess(Player player)
    {
        _possessedPlayer = player;
    }

	private void Update ()
    {
		if(!_possessedPlayer)
        {
            return;
        }
        
        if (Input.GetButtonDown(PlayerInputKeys.ActionEquip1))  { _possessedPlayer.OnInputActionPressed(PlayerInputKeys.ActionEquip1); }
        if (Input.GetButtonDown(PlayerInputKeys.ActionEquip2))  { _possessedPlayer.OnInputActionPressed(PlayerInputKeys.ActionEquip2); }
        if (Input.GetButtonDown(PlayerInputKeys.ActionEquip3))  { _possessedPlayer.OnInputActionPressed(PlayerInputKeys.ActionEquip3); }
        if (Input.GetButtonDown(PlayerInputKeys.ActionEquip4))  { _possessedPlayer.OnInputActionPressed(PlayerInputKeys.ActionEquip4); }
        if (Input.GetButtonDown(PlayerInputKeys.ActionUseItem)) { _possessedPlayer.OnInputActionPressed(PlayerInputKeys.ActionUseItem); }
        if (Input.GetButtonDown(PlayerInputKeys.ActionShoot))   { _possessedPlayer.OnInputActionPressed(PlayerInputKeys.ActionShoot); }
        if (Input.GetButtonDown(PlayerInputKeys.ActionToggleFiringMode)) { _possessedPlayer.OnInputActionPressed(PlayerInputKeys.ActionToggleFiringMode); }

        if (Input.GetButton(PlayerInputKeys.ActionShoot)) { _possessedPlayer.OnInputActionHold(PlayerInputKeys.ActionShoot); }
    }
}
