using System;
using GarbageScaler;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        public Player Player { get; set; }
        public MainPlayerCamera MainPlayerCamera { get; set; }
        public int Money { get; set; }
        public float Carry { get; set; }
        public int CarryLevel { get; set; } = 1;
        public float MoveSpeed { get; set; }
        
        // Volume
        public float MusicVolume { get; set; }
        public float SoundsVolume { get; set; }
    }
}