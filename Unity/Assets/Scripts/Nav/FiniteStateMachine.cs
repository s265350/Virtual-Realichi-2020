﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FiniteStateMachine<T>
{
    private GameObject _owner;
    private State _currentState;
    private State _previousState;
    private Dictionary<string, List<Transition>> _transitions = new Dictionary<string, List<Transition>>();
    private List<Transition> _currentTransitions = new List<Transition>();

    public FiniteStateMachine(GameObject owner){_owner = owner;}

    public void Tik()
    {
        State nextState = GetNextState();
        if(nextState != null)
            SetState(nextState);
        if(_currentState != null)
            _currentState.Tik();
    }

    public void SetState(State state)
    {
        if(state == _currentState) return;
        //Debug.Log($"Switching from {_currentState?.Name} state to {state.Name} state");
        _previousState = _currentState;
        _currentState?.Exit();
        _currentState = state;
        _transitions.TryGetValue(_currentState.Name, out _currentTransitions);
        _currentState.Enter();
    }

    public void ResetState() => SetState(_previousState);

    public State GetCurrentState(){return _currentState;}

    public void AddTransition(State fromState, State toState, Func<bool> transitionCondition)
    {
        if (_transitions.TryGetValue(fromState.Name, out var stateTransitions) == false)
        {
            stateTransitions = new List<Transition>();
            _transitions[fromState.Name] = stateTransitions;
        }
        stateTransitions.Add(new Transition(toState, transitionCondition));
    }

    private State GetNextState()
    {
        if(_currentTransitions == null)
            Debug.LogError($"Current State {_currentState.Name} has NO transitions");

        foreach (Transition transition in _currentTransitions)
        {
            if (transition.Condition())
                return transition.NextState;
        }
        return null;
    }
}

public class Transition
{
    public State NextState { get; }
    public Func<bool> Condition { get; }
    public Transition(State nextState, Func<bool> transitionCondition)
    {
        NextState = nextState;
        Condition = transitionCondition;
    }
}

public class State
{
    private string _name;
    public string Name => _name;
    private GameObject _owner;
    public Action Enter { get; }
    public Action Tik { get; }
    public Action Exit { get; }
    public State(string name, GameObject owner, Action enter, Action tik, Action exit)
    {
        _name = name;
        _owner = owner;
        Enter = enter;
        Tik = tik;
        Exit = exit;
    }
}