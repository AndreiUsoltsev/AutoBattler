namespace CodeBase.Core.FSM
{
    public class FsmState
    {
        protected readonly FinalStateMachine _finalStateMachine;

        public FsmState(FinalStateMachine finalStateMachine) 
            => _finalStateMachine = finalStateMachine;

        public virtual void Exit() { }

        public virtual void Enter() { }
        public virtual void Update() { }
    }
}