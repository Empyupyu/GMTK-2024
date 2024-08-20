using GarbageScaler;
using UnityEngine;
using NaughtyAttributes;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [field: SerializeField]
        [field: BoxGroup("Speed")]
        public float MoveSpeed { get; private set; }

        [field: SerializeField]
        [field: BoxGroup("Speed")]
        public float MaxMovementSpeed { get; private set; }

        [field: SerializeField]
        [field: BoxGroup("Speed")]
        public float RotationSpeed { get; private set; }

        // Prefabs
        [field: SerializeField]
        [field: BoxGroup("Prefabs")]
        public Player PlayerPrefab { get; private set; }

        [field: SerializeField]
        [field: BoxGroup("Prefabs")]
        public ProcessedGarbage ProcessedGarbagePrefab { get; private set; }
        
        [field: SerializeField]
        [field: BoxGroup("Prefabs")]
        public ParticleSystem ProcessedGarbageVfxPrefab { get; private set; }
    }
}