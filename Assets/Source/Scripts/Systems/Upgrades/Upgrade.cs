using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    public abstract class Upgrade : ScriptableObject
    {
        [field: SerializeField] public float EffectPerLevel;
        
        public abstract void ApplyUpgrade(PlayerData playerData);
    }
}