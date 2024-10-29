using UnityEngine.SceneManagement;

namespace CodeBase.Core.Services.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        private const string GameSceneName = "Game";

        public void LoadGameScene()
            => SceneManager.LoadScene(GameSceneName);
    }
}