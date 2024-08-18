using Kuhpik;

namespace GarbageScaler.Systems.Loading
{
    public class CameraLoadingSystem : GameSystem
    {
        public override void OnInit()
        {
            game.MainPlayerCamera = FindObjectOfType<MainPlayerCamera>();

            var virtualCamera = game.MainPlayerCamera.VirtualCamera;
            virtualCamera.Follow = game.Player.transform;
        }
    }
}