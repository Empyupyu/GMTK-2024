using System.Collections.Generic;
using UnityEngine;

namespace EGameSystems
{
    public sealed class GameState : MonoBehaviour
    {
        [field : SerializeField] public GameStateType GameStateType { get; private set; }
        [field : SerializeField] public  List<GameStateType> AdditionStatesOnStart { get; private set; }
        public List<GameSystem> GameSystems { get; private set; }

        private bool isAwaked;
        private bool isStardet;

        public void InitializeSystems()
        {
            GameSystems = new List<GameSystem>();
            GameSystems.AddRange(transform.GetComponentsInChildren<GameSystem>());
        }

        public void OnAwake()
        {
            if (isAwaked) return;

            for (int i = 0; i < GameSystems.Count; i++)
            {
                GameSystems[i].OnAwake();
            }

            isAwaked = true;
        }

        public void OnStart()
        {
            if (isStardet) return;

            for (int i = 0; i < GameSystems.Count; i++)
            {
                GameSystems[i].OnStart();
            }

            isStardet = true;
        }

        public void OnStateEnter()
        {
            for (int i = 0; i < GameSystems.Count; i++)
            {
                GameSystems[i].OnStateEnter();
            }
        }

        public void OnStateExit()
        {
            for (int i = 0; i < GameSystems.Count; i++)
            {
                GameSystems[i].OnStateExit();
            }
        }

        public void OnUpdate()
        {
            for (int i = 0; i < GameSystems.Count; i++)
            {
                GameSystems[i].OnUpdate();
            }
        }

        public void OnFixedUpdate()
        {
            for (int i = 0; i < GameSystems.Count; i++)
            {
                GameSystems[i].OnFixedUpdate();
            }
        }
    }
}

