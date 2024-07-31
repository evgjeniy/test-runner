using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Transform cubesStackRoot;

    public IMovement Move { get; private set; }
    public IStack Stack { get; private set; }
    public IInventory Inventory { get; private set; }
    public IHealth Health { get; private set; }

    public void Initialize(LevelConfig levelConfig, IInputService inputService)
    {
        Move = new PlayerMovement(inputService, playerConfig, transform);
        Stack = new PlayerStack(levelConfig, cubesStackRoot);
        Inventory = new PlayerInventory(levelConfig, Stack, Services.All.Resolve<GameLoopStateMachine>());
        Health = new PlayerHealth(Stack, Services.All.Resolve<GameLoopStateMachine>());
    }

    private void OnEnable()  { Move.Enable();  Inventory.Enable();  }
    private void OnDisable() { Move.Disable(); Inventory.Disable(); }
    private void Update() => Move.MoveForward();
}