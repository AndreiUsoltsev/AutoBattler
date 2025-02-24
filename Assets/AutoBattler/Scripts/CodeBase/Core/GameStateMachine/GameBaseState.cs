using CodeBase.Core.FSM;

namespace CodeBase.Core.GameLifeStates
{
    public abstract class GameBaseState : FsmState
    {
        protected GameBaseState(GameStateMachine finalStateMachine) : base(finalStateMachine)
        {
        }

        protected void SwitchToGameLoadState()
            => _finalStateMachine.SetState<GameLoadState>();

        protected void SwitchToPlayLoopState()
            => _finalStateMachine.SetState<PlayLoopState>();
    }
}