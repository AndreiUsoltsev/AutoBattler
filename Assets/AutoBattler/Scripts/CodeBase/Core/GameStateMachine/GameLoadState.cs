using CodeBase.Core.Services.SceneLoading;

namespace CodeBase.Core.GameLifeStates
{
    public class GameLoadState : GameBaseState
    {
        private readonly ISceneLoader _sceneLoader;

        public GameLoadState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader) : base(gameStateMachine)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            base.Enter();

            _sceneLoader.LoadGameScene();
        }
    }
}