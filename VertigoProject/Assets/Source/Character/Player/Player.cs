using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : Character
{
    public CharacterController CharacterController { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        CharacterController = GetComponent<CharacterController>();
    }

    protected override void Update()
    {
        base.Update();
        
    }

    public void OnInputAxis(string axisName, float value)
    {
        
    }

    public void OnInputAction(string actionName)
    {
        if(actionName == PlayerInputKeys.ActionEquip1)
        {
            EquipmentManager.Equip(AttachmentSlotId.RightHand, 0);
        }
        else if(actionName == PlayerInputKeys.ActionEquip2)
        {
            EquipmentManager.Equip(AttachmentSlotId.RightHand, 1);
        }
        else if(actionName == PlayerInputKeys.ActionEquip3)
        {
            EquipmentManager.Equip(AttachmentSlotId.RightHand, 2);
        }
        else if(actionName == PlayerInputKeys.ActionEquip4)
        {
            EquipmentManager.Equip(AttachmentSlotId.RightHand, 3);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        
    }
    
}
