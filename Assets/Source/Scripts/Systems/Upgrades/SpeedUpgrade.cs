using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    [CreateAssetMenu]
    public class SpeedUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameData gameData)
        {
            gameData.MoveSpeed += EffectPerLevel;
            Bootstrap.Instance.SaveGame();
        }
    }
}