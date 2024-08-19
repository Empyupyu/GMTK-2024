using GarbageScaler.GameSignals;
using GarbageScaler.UIScreens;
using Kuhpik;
using Supyrb;

namespace GarbageScaler.Systems.Game
{
    public class ShopSystem : GameSystemWithScreen<ShopUIScreen>
    {
        public override void OnInit()
        {
            Signals.Get<PlayerEnteredShopSignal>().AddListener(OnPlayerEnteredShop);
            Signals.Get<PlayerExitedShopSignal>().AddListener(OnPlayerExitedShop);
        }
        
        private void OnPlayerEnteredShop()
        {
            screen.Open();
        }
     
        private void OnPlayerExitedShop()
        {
            screen.Close();
        }
    }
}