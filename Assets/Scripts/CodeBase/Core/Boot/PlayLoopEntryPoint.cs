using CodeBase.Core.GameLifeStates;
using VContainer.Unity;

namespace CodeBase.Core.Boot
{
    public class PlayLoopEntryPoint : IStartable
    {
        private readonly PlayLoopState _playLoopState;
        private readonly GameStateMachine _gameStateMachine;

        public PlayLoopEntryPoint(PlayLoopState playLoopState, GameStateMachine gameStateMachine)
        {
            _playLoopState = playLoopState;
            _gameStateMachine = gameStateMachine;
        }

        public void Start()
        {
            _gameStateMachine.RegisterState(_playLoopState);

            _gameStateMachine.SetState<PlayLoopState>();
        }
    }
}