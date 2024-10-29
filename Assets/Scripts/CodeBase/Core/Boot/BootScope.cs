using CodeBase.Core.Boot;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class BootScope : LifetimeScope
{
    [SerializeField] private GameBootstrapper _gameBootstrapper;

    protected override void Configure(IContainerBuilder builder) 
        => RegisterBootstrapper(builder);

    private void RegisterBootstrapper(IContainerBuilder builder) 
        => builder.RegisterComponent(_gameBootstrapper);
}
