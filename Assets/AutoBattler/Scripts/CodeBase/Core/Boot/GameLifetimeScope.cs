using CodeBase.Core.GameLifeStates;
using CodeBase.Core.Services.SceneLoading;
using CodeBase.Services.Assets;
using CodeBase.Updater;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Core.GameLifeTime
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"Bind game life time scope");
            RegisterSceneLoader(builder);
            RegisterAssetsLoader(builder);
            RegisterAddressablePrefabsLoader(builder);
            RegisterMonoUpdater(builder);
            RegisterBootState(builder);
            RegisterGameLoadState(builder);
            RegisterGameStateMachine(builder);
        }

        private void RegisterGameLoadState(IContainerBuilder builder) 
            => builder.Register<GameLoadState>(Lifetime.Singleton);

        private void RegisterGameStateMachine(IContainerBuilder builder) 
            => builder.Register<GameStateMachine>(Lifetime.Singleton);

        private void RegisterBootState(IContainerBuilder builder) 
            => builder.Register<BootState>(Lifetime.Singleton);

        private void RegisterMonoUpdater(IContainerBuilder builder)
        {
            IMonoUpdater monoUpdater = new MonoUpdaterFactory().Get();
            builder.RegisterInstance(monoUpdater);
        }

        private static void RegisterAddressablePrefabsLoader(IContainerBuilder builder) 
            => builder.Register<IPrefabsLoader, AddressablesPrefabsLoader>(Lifetime.Singleton);

        private void RegisterAssetsLoader(IContainerBuilder builder) 
            => builder.Register<IAssetsLoader, AssetsLoader>(Lifetime.Singleton);

        private static void RegisterSceneLoader(IContainerBuilder builder) 
            => builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
    }
}