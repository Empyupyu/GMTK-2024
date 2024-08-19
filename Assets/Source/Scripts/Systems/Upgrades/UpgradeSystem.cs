using Kuhpik;
using Supyrb;
using UnityEngine;

namespace GarbageScaler
{
    public class UpgradeSystem : GameSystem
    {
        [SerializeField] private CarryUpgrade _carryUpgrade;
        [SerializeField] private SpeedUpgrade _speedUpgrade;
        
        public override void OnInit()
        {
            Signals.Get<UpgradeCarrySignal>().AddListener(UpgradeCarry);
            Signals.Get<UpgradeSpeedSignal>().AddListener(UpgradeSpeed);

            UpgradeCarry();
            UpgradeCarry();
        }

        private void UpgradeSpeed()
        {
            _speedUpgrade.ApplyUpgrade(game);
        }
        
        private void UpgradeCarry()
        {
            _carryUpgrade.ApplyUpgrade(game);
        }
    }
}
