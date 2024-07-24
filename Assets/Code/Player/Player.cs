using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Transform cubesStackRoot;

    public IInputService Input { get; private set; }
    public IMovement Move { get; private set; }
    public IInventory Inventory { get; private set; }
    public IHealth Health { get; private set; }

    public void Initialize(LevelConfig levelConfig)
    {
        Input = Services.All.Resolve<IInputService>();
        Move = new PlayerMovement(Input, playerConfig, transform);
        Inventory = new PlayerInventory(levelConfig, cubesStackRoot);
        Health = new PlayerHealth(Inventory);

        enabled = true;
    }

    private void OnEnable() => Move.Enable();
    private void OnDisable() => Move.Disable();

    private void Update()
    {
        Move.MoveForward();
        Input.HandleSwipe();
    }
}