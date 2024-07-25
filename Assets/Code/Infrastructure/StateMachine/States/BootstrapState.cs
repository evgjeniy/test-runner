using UnityEngine;

public class BootstrapState : IState
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly Services _services;

    public BootstrapState(IGameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, Services services)
    {
        _gameStateMachine = gameStateMachine;
        _coroutineRunner = coroutineRunner;
        _services = services;

        RegisterServices();
    }

    private void RegisterServices()
    {
        _services.Register<ILogService>(new DebugLogService());

        _services.Register<IGameStateMachine>(_gameStateMachine);
        _services.Register<ICoroutineRunner>(_coroutineRunner);
        _services.Register<ISceneLoader>(new SceneLoader(_coroutineRunner));

        var configProvider = _services.Register<IConfigProvider>(new ConfigProvider());
        _services.Register<IInputService>(new TouchInputService(configProvider));
    }

    public void Enter()
    {
        Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 0;

        var sceneLoader = _services.Resolve<ISceneLoader>();
        sceneLoader.Load(Const.Scenes.Game.Index, onLoaded: SwitchState);
    }

    private void SwitchState()
    {
        _gameStateMachine.Enter<MainMenuState>();
    }
}