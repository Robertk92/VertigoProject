using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * The StateMachine serves both as a logic seperator and an animation controller
 * The activate state is used by the animator to determine what animation to play
 * The states themselves contain gameplay logic that should run during said state
 */
public class StateMachine
{
    public State ActiveState { get; private set; }
    public StateId ActiveStateId { get { return ActiveState.Id; } }

    private Dictionary<StateId, State> _registeredStates = new Dictionary<StateId, State>();
    public IEnumerable<KeyValuePair<StateId, State>> RegisteredStates { get { return _registeredStates; } }

    private Character _character;
    private StateId _defaultStateId;

    public event Action<StateId> OnStateChanged = delegate { };

    public StateMachine(Character character, StateId defaultStateId)
    {
        _defaultStateId = defaultStateId;
        _character = character;
    }

    /// <summary>
    /// Register a new state to the state machine, registered states can be activated
    /// Only 1 state per type should be registered
    /// </summary>
    /// <typeparam name="T">The type of the state</typeparam>
    /// <param name="stateId">The id of the state</param>
    public void RegisterState<T>(StateId stateId) where T : State, new()
    {
        Debug.AssertFormat(!_registeredStates.ContainsKey(stateId),
            string.Format("A state with id '{0}' was already registered", stateId));
        T state = new T();
        state.Register(stateId, this, _character);
        _registeredStates.Add(stateId, state);
        state.Init();

        if(stateId == _defaultStateId)
        {
            ActivateState(stateId);
        }
    }

    /// <summary>
    /// Attempts to activate the given state using the character state transition rules
    /// </summary>
    /// <param name="state">The state to activate</param>
    /// <returns>Wheter or not the stata transition is allowed</returns>
    public bool TryActivateState(StateId state)
    {
        if (CanTransitionTo(state))
        {
            ActivateState(state);
            return true;
        }
        return false;
    }

    private void ActivateState(StateId state)
    {
        if (ActiveState != null)
        {
            if(ActiveState.Id == state)
            {
                return;
            }
            ActiveState.Deactivate();
        }
        
        ActiveState = _registeredStates[state];
        ActiveState.Activate();
        OnStateChanged(state);
    }

    private bool CanTransitionTo(StateId state)
    {
        CharacterStateTransitionRule rule = _character.Context.StateTransitionRules.Rules.FirstOrDefault(x => x.state == ActiveStateId);

        if (rule == null)
        {
            return true;
        }
        
        return rule.allowedStates.Contains(state);
    }
}
