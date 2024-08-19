using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    [CreateAssetMenu]
    public class CarryUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameData gameData)
        {
            if (gameData.Carry >= .6f) return;
            
            gameData.Carry += EffectPerLevel;
            Bootstrap.Instance.SaveGame();
        }
    }
}