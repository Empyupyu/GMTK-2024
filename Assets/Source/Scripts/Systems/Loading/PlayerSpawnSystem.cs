using Kuhpik;

namespace GarbageScaler.Systems.Loading
{
    public class PlayerSpawnSystem : GameSystem
    {
        public override void OnInit()
        {
            game.Player = Instantiate(config.PlayerPrefab);
        }
    }
}