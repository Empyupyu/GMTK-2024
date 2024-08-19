using System.Collections.Generic;
using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    public class UpgradeSystem : GameSystem
    {
        public override void OnInit()
        {
            
        }
    }

    public abstract class Upgrade : ScriptableObject
    {
        [field: SerializeField] public float EffectPerLevel;
        
        public abstract void ApplyUpgrade(PlayerData playerData);
    }
    
    public class CarryUpgrade : Upgrade
    {
        public override void ApplyUpgrade(PlayerData playerData)
        {
            playerData.Carry += EffectPerLevel;
            Bootstrap.Instance.SaveGame();
        }
    }
    
    public class SpeedUpgrade : Upgrade
    {
        public override void ApplyUpgrade(PlayerData playerData)
        {
            playerData.MoveSpeed += EffectPerLevel;
            Bootstrap.Instance.SaveGame();
        }
    }
}
