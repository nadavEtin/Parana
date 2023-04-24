using Assets.Scripts.Utility;
using GameCore;
using VContainer;
using VContainer.Unity;

namespace VContainer
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameDirector>();
            builder.Register<EventBus>(Lifetime.Singleton);
        }
    }
}


