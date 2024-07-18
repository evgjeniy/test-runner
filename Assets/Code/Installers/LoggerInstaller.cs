using Zenject;

public class LoggerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
#if UNITY_EDITOR
        Container.Bind<ILogService>().To<DebugLogService>().AsSingle();
#else
        Container.Bind<ILogService>().To<EmptyLogService>().AsSingle();
#endif
    }
}