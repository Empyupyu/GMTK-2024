using UnityEngine;

public class LookAtCameraComponent : MonoBehaviour
{
    private Transform target;

    private void Awake()
    {
        target = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + target.rotation * Vector3.back, target.rotation * Vector3.up);
    }
}
