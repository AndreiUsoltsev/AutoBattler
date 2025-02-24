using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Core.Boot
{
    public class BootScope : LifetimeScope
    {
        [SerializeField] private GameBootstrapper _gameBootstrapper;

        protected override void Configure(IContainerBuilder builder) 
            => RegisterBootstrapper(builder);

        private void RegisterBootstrapper(IContainerBuilder builder) 
            => builder.RegisterComponent(_gameBootstrapper);
    }
}
