using Kuhpik;

namespace GarbageScaler.Systems.Loading
{
    public class LoadingEndSystem : GameSystem
    {
        public override void OnInit()
        {
            Bootstrap.Instance.ChangeGameState(GameStateID.Game);
        }
    }
}