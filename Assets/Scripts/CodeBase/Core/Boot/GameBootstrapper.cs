using CodeBase.Core.GameLifeStates;
using CodeBase.Updater;
using UnityEngine;
using VContainer;

namespace CodeBase.Core.Boot
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private BootState _bootState;
        private GameLoadState _gameLoadState;
        private IMonoUpdater _monoUpdater;

        [Inject]
        public void Constructor(GameStateMachine gameStateMachine, BootState bootState, GameLoadState gameLoadState, IMonoUpdater monoUpdater)
        {
            _gameStateMachine = gameStateMachine;
            _bootState = bootState;
            _gameLoadState = gameLoadState;
            _monoUpdater = monoUpdater;
        }

        private void Start()
        {
            _monoUpdater.Add(_gameStateMachine);

            _gameStateMachine.RegisterState(_bootState);
            _gameStateMachine.RegisterState(_gameLoadState);

            _gameStateMachine.SetState<BootState>();
        }
    }
}