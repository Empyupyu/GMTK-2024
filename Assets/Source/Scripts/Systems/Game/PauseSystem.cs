using GarbageScaler.UIScreens;
using Kuhpik;
using UnityEngine;

namespace GarbageScaler.Systems.Game
{
    public class PauseSystem : GameSystemWithScreen<PauseMenuUIScreen>
    {
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ToggleMenuState();
        }
        
        private void ToggleMenuState()
        {
            if (screen.IsOpened)
                screen.Close();
            else
                screen.Open();
            
            screen.IsOpened = !screen.IsOpened;
        }
    }
}