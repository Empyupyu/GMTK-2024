using GarbageScaler;
using UnityEngine;
using NaughtyAttributes;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [field: SerializeField] [field: BoxGroup("Moving")] public float MoveSpeed { get; private set; }
        
        // Prefabs
        [field: SerializeField] [field: BoxGroup("Prefabs")] public Player PlayerPrefab { get; private set; }
    }
}