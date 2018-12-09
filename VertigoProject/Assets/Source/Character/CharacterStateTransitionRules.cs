using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStateTransitionRule
{
    public StateId state;
    public List<StateId> allowedStates;
}

/**
 * The CharacterStateTransitionRules determine to what states the StateMachine can transition from a given other state
 */
[CreateAssetMenu]
public class CharacterStateTransitionRules : ScriptableObject
{
    [Tooltip("The rules that determine if a state can transition to another state, unlisted states can always transition to any other state")]
    public List<CharacterStateTransitionRule> Rules = new List<CharacterStateTransitionRule>();
}
