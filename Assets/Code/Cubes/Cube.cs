using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public ColorTaskConfig ColorTask { get; private set; }
    public Color Color => ColorTask.Color;

    public void Construct(ColorTaskConfig colorTask)
    {
        ColorTask = colorTask;

        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(meshRenderer.material) { color = colorTask.Color };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player))
            return;

        player.Stack.Collect(this);
    }
}