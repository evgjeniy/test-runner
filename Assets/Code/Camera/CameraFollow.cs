using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 lookOffset = new(0.0f, 1.5f, 2.5f);
    [SerializeField] private Vector3 positionOffset = new(4.0f, 4.5f, -7.5f);

    private void LateUpdate()
    {
        transform.position = target.position + positionOffset;
        transform.LookAt(target.position + lookOffset);
    }
}