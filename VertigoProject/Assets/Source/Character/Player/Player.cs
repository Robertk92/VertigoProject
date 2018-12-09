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

    public void OnInputActionPressed(string actionName)
    {
        StateMachine.ActiveState.OnInputActionPressed(actionName);
    }

    public void OnInputActionHold(string actionName)
    {
        StateMachine.ActiveState.OnInputActionHold(actionName);
    }

    // For debug purposes
    private void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUILayout.Label("=====================");
        GUILayout.Label("======Inventory======");
        GUILayout.Label("=====================");
        foreach (InventoryItem inventoryItem in EquipmentManager.Inventory)
        {
            GUILayout.Label(inventoryItem.context.name);
        }
        GUILayout.Label("=====================");

        GUILayout.Label(string.Format("ActiveState: {0}", StateMachine.ActiveStateId));
    }
}
