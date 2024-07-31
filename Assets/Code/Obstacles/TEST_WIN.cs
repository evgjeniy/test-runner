using UnityEngine;

public class TEST_WIN : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player))
            return;

        Services.All.Resolve<GameLoopStateMachine>().Enter<GameWinState>();
    }
}