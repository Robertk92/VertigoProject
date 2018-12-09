using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Activate()
    {
        base.Activate();
        Character.Animator.SetInteger("State", (int)Id);
    }
}
