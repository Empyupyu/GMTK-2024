using GarbageScaler.Extensions;
using GarbageScaler.GameSignals;
using GarbageScaler.UIScreens;
using Kuhpik;
using Supyrb;

namespace GarbageScaler.Systems.Game
{
    public class MoneySystem : GameSystemWithScreen<PlayerStatsUIScreen>
    {
        public override void OnInit()
        {
            Signals.Get<AddMoneySignal>().AddListener(AddMoney);
            Signals.Get<RemoveMoneySignal>().AddListener(RemoveMoney);
        }
        
        private void AddMoney(int money)
        {
            var updatedMoney = game.Money + money;
            screen.MoneyText.DOCounter(game.Money, updatedMoney, 0.5f);
            game.Money = updatedMoney;
        }
        
        private void RemoveMoney(int money)
        {
            var updatedMoney = game.Money - money;
            screen.MoneyText.DOCounter(game.Money, updatedMoney, 0.5f);
            game.Money = updatedMoney;
        }
    }
}