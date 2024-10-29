using CodeBase.Core.FSM;
using CodeBase.Updater;
using UnityEngine;

namespace CodeBase.Core.GameLifeStates
{
    public class GameStateMachine : FinalStateMachine, IUpdatable
    {
        public bool IsRegistered<T>() where T : FsmState 
            => _states.ContainsKey(typeof(T));

        public void MonoUpdate() 
            => Update();
    }
}