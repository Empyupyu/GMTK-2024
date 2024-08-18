using Kuhpik;

namespace GarbageScaler.Systems.Loading
{
    public class CameraLoadingSystem : GameSystem
    {
        public override void OnInit()
        {
            game.MainPlayerCamera = FindObjectOfType<MainPlayerCamera>();

            var virtualCamera = game.MainPlayerCamera.VirtualCamera;
            var playerTransform = game.Player.transform;
            virtualCamera.Follow = playerTransform;
            virtualCamera.LookAt = playerTransform;
        }
    }
}