using System.Collections.Generic;
using UnityEngine;

namespace EGameSystems
{
    public class GameData
    {
        //public Player Player;
        //public Enemy PlayerChoiceEnemyForTarget;

        //public Aim Aim;
        public Vector3 AimStartPositionOnScreen;

        //public HubBase HubBase;
        //public Level Level;
        //public CinemachineVirtualCamera PlayerVirtualCamera;

        //public List<Enemy> Enemies = new List<Enemy>();

        //public PlayerCharacteristics PlayerCharacteristics;
        public float PlayerAttackRate;

        public bool DisableInputs;
        public bool LevelCompleted;
        public bool PlayerIsGround = true;

        //public bool PlayerAvailable(Transform player) => player.Equals(Player.transform);
    }
}

