using System.Collections;
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
        
        if(Input.GetButtonDown(PlayerInputKeys.ActionEquip1))
        {
            _possessedPlayer.OnInputAction(PlayerInputKeys.ActionEquip1);
        }

        if (Input.GetButtonDown(PlayerInputKeys.ActionEquip2))
        {
            _possessedPlayer.OnInputAction(PlayerInputKeys.ActionEquip2);
        }
        
        if (Input.GetButtonDown(PlayerInputKeys.ActionEquip3))
        {
            _possessedPlayer.OnInputAction(PlayerInputKeys.ActionEquip3);
        }

        if (Input.GetButtonDown(PlayerInputKeys.ActionEquip4))
        {
            _possessedPlayer.OnInputAction(PlayerInputKeys.ActionEquip4);
        }
    }
}
