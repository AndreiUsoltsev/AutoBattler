using System;
using System.Collections.Generic;


namespace CodeBase.Core.FSM
{
    public class FinalStateMachine
    {
        public FsmState CurrentState { get; private set; }

        protected readonly Dictionary<Type, FsmState> _states;

        public FinalStateMachine()
        {
            _states = new();
        }

        public void RegisterState(FsmState newState)
            => _states[newState.GetType()] = newState;

        public virtual void SetState<T>() where T : FsmState
        {
            Type type = typeof(T);

            if (_states.ContainsKey(type) == false)
                throw new NullReferenceException($"State of type {type} is not registered");

            UnityEngine.Debug.Log($"<color=green>Switch from {CurrentState} to {typeof(T)}</color>");

            CurrentState?.Exit();

            CurrentState = _states[type];
            CurrentState.Enter();
        }

        public void Update()
            => CurrentState?.Update();
    }
}