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
    }
}