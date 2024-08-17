using UnityEngine;

namespace EGameSystems
{
    public abstract class GameSystem : MonoBehaviour
    {
        protected GameData gameData { get; private set; }
        protected PlayerData playerData { get; private set; }
        protected ConfigData configData { get; private set; }

        public void InitializeDatas(GameData game, PlayerData player, ConfigData config)
        {
            gameData = game;
            playerData = player;
            configData = config;
        }

        public virtual void OnAwake() { }
        public virtual void OnSubscribe() { }
        public virtual void OnEnabled() { }
        public virtual void OnStart() { }
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnDisabled() { }
        public virtual void OnDestroed() { }
    }
}

