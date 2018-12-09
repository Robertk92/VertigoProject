using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterContext : ScriptableObject
{
    [SerializeField]
    private CharacterStateTransitionRules _stateTransitionRules;
    public CharacterStateTransitionRules StateTransitionRules { get { return _stateTransitionRules; } }
}
