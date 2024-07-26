public class GameLoopExitState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public GameLoopExitState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
    
    public void Enter()
    {
        var sceneLoader = Services.All.Resolve<ISceneLoader>();
        sceneLoader.Load(Const.Scenes.Game.Index, onLoaded: _gameStateMachine.Enter<MainMenuState>);
    }
}