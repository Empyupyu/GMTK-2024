using Kuhpik;
using UnityEngine;

namespace GarbageScaler.Systems.Loading
{
    public class PlayerSpawnSystem : GameSystem
    {
        [SerializeField] private Transform playerSpawnPoint;
        
        public override void OnInit()
        {
            game.Player = Instantiate(config.PlayerPrefab, playerSpawnPoint.position, Quaternion.identity);
        }
    }
}