using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _stateMachine;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly Services _services;

    public BootstrapState(GameStateMachine stateMachine, ICoroutineRunner coroutineRunner, Services services)
    {
        _stateMachine = stateMachine;
        _coroutineRunner = coroutineRunner;
        _services = services;

        RegisterServices();
    }

    private void RegisterServices()
    {
        _services.Register<ILogService>(new DebugLogService());

        _services.Register<GameStateMachine>(_stateMachine);
        _services.Register<ICoroutineRunner>(_coroutineRunner);
        _services.Register<ISceneLoader>(new SceneLoader(_coroutineRunner));

        var serializer = _services.Register<ISerializeService>(new JsonSerializeService());
        _services.Register<ISaveService>(new CashedSaveService(new PlayerPrefsSaveService(serializer)));

        var configProvider = _services.Register<IConfigProvider>(new ConfigProvider());
        _services.Register<IInputService>
        (
#if UNITY_EDITOR
            new StandaloneInputService()
#else
            new TouchInputService(configProvider)
#endif
        );
    }

    public void Enter()
    {
        Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 0;

        var sceneLoader = _services.Resolve<ISceneLoader>();
        sceneLoader.Load(Const.Scenes.Game.Index, onLoaded: _stateMachine.Enter<MainMenuState>);
    }
}