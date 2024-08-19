using DG.Tweening;
using GarbageScaler.GameSignals;
using Kuhpik;
using Supyrb;
using UnityEngine;

namespace GarbageScaler.UIScreens
{
    public class ShopUIScreen : UIScreen
    {
        [field: SerializeField] public ShopUpgradeUI CraneUpgrade { get; private set; }
        
        private const float UpgradeScaleTime = 0.5f;

        public override void Subscribe()
        {
            Signals.Get<AddMoneySignal>().AddListener(_ => RefreshUpgrades(), 1);
            CraneUpgrade.OnClick += OnCraneUpgrade;
        }

        public override void Open()
        {
            base.Open();
            RefreshUpgrades();
            
            CraneUpgrade.transform.localScale = Vector3.zero;
            CraneUpgrade.transform.DOScale(Vector3.one, UpgradeScaleTime);
        }

        public override void Close()
        {
            CraneUpgrade.transform.DOScale(Vector3.zero, UpgradeScaleTime)
                .OnComplete(base.Close);
        }

        private void OnCraneUpgrade()
        {
            Signals.Get<UpgradeCarrySignal>().Dispatch();
            Signals.Get<RemoveMoneySignal>().Dispatch(10);
            
            CraneUpgrade.DisableClicking();
            CraneUpgrade.transform.DOScale(Vector3.zero, UpgradeScaleTime)
                .OnComplete(() =>
                {
                    RefreshUpgrades();
                    CraneUpgrade.transform.DOScale(Vector3.one, UpgradeScaleTime)
                        .OnComplete(() =>
                        {
                            CraneUpgrade.EnableClicking();
                        });
                });
        }

        private void RefreshUpgrades()
        {
            var upgradeCost = 10;
            CraneUpgrade.UpdateData(Bootstrap.Instance.GameData.CarryLevel + 1, upgradeCost);
            if (Bootstrap.Instance.GameData.Money >= upgradeCost)
                CraneUpgrade.Unlock();
            else
                CraneUpgrade.Lock();
        }
    }
}