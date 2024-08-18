using UnityEngine;

namespace GarbageScaler
{
    public class ProcessedGarbage : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}