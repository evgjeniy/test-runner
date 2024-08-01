using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private Material _material;

    public Color Color
    {
        get => _material.color;
        set => _material.color = value;
    }

    public void Construct(Color color)
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = _material = new Material(meshRenderer.material) { color = color };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player))
            return;

        player.Stack.Collect(this);
    }
}