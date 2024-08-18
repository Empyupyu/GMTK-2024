using UnityEngine;

namespace GarbageScaler
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}