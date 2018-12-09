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
}
