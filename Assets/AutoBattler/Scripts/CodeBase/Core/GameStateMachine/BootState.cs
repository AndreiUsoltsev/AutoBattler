using CodeBase.Core.FSM;

namespace CodeBase.Core.GameLifeStates
{
    public class BootState : GameBaseState
    {
        public BootState(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            SwitchToGameLoadState();
        }
    }
}