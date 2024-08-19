using Kuhpik;
using UnityEngine;

namespace GarbageScaler
{
    [CreateAssetMenu]
    public class SpeedUpgrade : Upgrade
    {
        public override void ApplyUpgrade(PlayerData playerData)
        {
            playerData.MoveSpeed += EffectPerLevel;
            Bootstrap.Instance.SaveGame();
        }
    }
}