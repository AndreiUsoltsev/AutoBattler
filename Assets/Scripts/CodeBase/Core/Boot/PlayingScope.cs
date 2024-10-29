using CodeBase.Core.Boot;
using CodeBase.Core.GameLifeStates;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Core.GameLifeTime
{
    public class PlayingScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterPlayLoopState(builder);
            RegisterEntryPoint(builder);
        }

        private static void RegisterPlayLoopState(IContainerBuilder builder) 
            => builder.Register<PlayLoopState>(Lifetime.Singleton);

        private static void RegisterEntryPoint(IContainerBuilder builder) 
            => builder.RegisterEntryPoint<PlayLoopEntryPoint>();
    }
}