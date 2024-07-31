using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Transform cubesStackRoot;

    public IMovement Movement { get; private set; }
    public IStack Stack { get; private set; }
    public IInventory Inventory { get; private set; }
    public IHealth Health { get; private set; }

    public void Initialize(LevelConfig levelConfig, IInputService inputService)
    {
        Movement = new PlayerMovement(inputService, playerConfig, transform);
        Stack = new PlayerStack(levelConfig, cubesStackRoot);
        Inventory = new PlayerInventory(levelConfig, Stack, Services.All.Resolve<GameLoopStateMachine>());
        Health = new PlayerHealth(Stack, Services.All.Resolve<GameLoopStateMachine>());
    }

    private void OnEnable()  { Movement.Enable();  Inventory.Enable();  }
    private void OnDisable() { Movement.Disable(); Inventory.Disable(); }
    private void Update() => Movement.MoveForward();
}