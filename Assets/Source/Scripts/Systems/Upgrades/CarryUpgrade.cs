using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    [CreateAssetMenu]
    public class CarryUpgrade : Upgrade
    {
        public override void ApplyUpgrade(PlayerData playerData)
        {
            if (playerData.Carry >= .6f) return;
            
            playerData.Carry += EffectPerLevel;
            Bootstrap.Instance.SaveGame();
        }
    }
}