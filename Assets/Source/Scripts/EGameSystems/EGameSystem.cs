using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EGameSystems
{
    public class EGameSystem : MonoBehaviour
    {
        public static EGameSystem Instance { get; private set; }

        public GameData GameData { get; } = new GameData();
        public PlayerData PlayerData { get; private set; } = new PlayerData();

        [SerializeField] private ConfigData configData;

        private List<GameState> gameStates = new List<GameState>();
        private List<GameSystem> gameSystems = new List<GameSystem>();
        private List<GameState> additionGameStates = new List<GameState>();

        private GameState currentGameState;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            LoadGame();
            AddStates();
            AddSystems();
            InitializeSystemDatas();
            Subscribe();

            SwitchGameState(GameStateType.Loading);
        }

        private void Subscribe()
        {
            for(int i = 0; i < gameSystems.Count; i++)
            {
                gameSystems[i].OnSubscribe();
            }
        }

        private void AddStates()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameState state = transform.GetChild(i).GetComponent<GameState>();

                if (state != null)
                {
                    gameStates.Add(state);
                }
                else
                {
                    new NullReferenceException();
                    return;
                }
            }
        }

        private void AddSystems()
        {
            for (int i = 0; i < gameStates.Count; i++)
            {
                gameStates[i].InitializeSystems();
                gameSystems.AddRange(gameStates[i].GameSystems);
            }
        }

        private void InitializeSystemDatas()
        {
            for (int i = 0; i < gameSystems.Count; i++)
            {
                gameSystems[i].InitializeDatas(GameData, PlayerData, configData);
            }
        }

        private void LoadGame()
        {
            var save = PlayerPrefs.GetString("SaveGame");

            if(save != "") PlayerData = JsonUtility.FromJson<PlayerData>(save);
        }

        public void SaveGame()
        {
            var save = JsonUtility.ToJson(PlayerData);

            PlayerPrefs.SetString("SaveGame", save);
            PlayerPrefs.Save();
        }

        public  GameSystem GetGameSystem<T>() where T : GameSystem
        {
            return gameSystems.FirstOrDefault(x => x.GetType() == typeof(T));
        }

        public void SwitchGameState(GameStateType stateType)
        {
            var state = GetState(stateType);

            if(state != null)
            {
                OnStateExit();

                currentGameState = state;

                OnStateEnter();
            }

            additionGameStates.Clear();

            if (currentGameState.AdditionStatesOnStart.Count > 0)
            {
                for (int i = 0; i < currentGameState.AdditionStatesOnStart.Count; i++)
                {
                    var addState = currentGameState.AdditionStatesOnStart[i];
                    additionGameStates.Add(GetState(addState));
                }
            }

            Debug.Log("Enter state: " + currentGameState.GameStateType);

            OnAwake();
            OnStart();
        }

        private GameState GetState(GameStateType stateType)
        {
            return gameStates.FirstOrDefault(s => s.GameStateType == stateType);
        }

        private void OnAwake()
        {
            currentGameState.OnAwake();

            AdditionStateOnAwake();
        }

        private void AdditionStateOnAwake()
        {
            if (!HasAdditionStates()) return;

            for (int i = 0; i < additionGameStates.Count; i++)
            {
                additionGameStates[i].OnAwake();
            }
        }

        private void OnStateEnter()
        {
            currentGameState.OnStateEnter();
        }

        private void OnStateExit()
        {
            currentGameState?.OnStateExit();
        }

        private void OnStart()
        {
            currentGameState.OnStart();

            AdditionStateOnStart();
        }

        private void AdditionStateOnStart()
        {
            if (!HasAdditionStates()) return;

            for (int i = 0; i < additionGameStates.Count; i++)
            {
                additionGameStates[i].OnStart();
            }
        }

        private void Update()
        {
            if (!HasCurrentState()) return;

            currentGameState.OnUpdate();

            AdditionStateOnUpdate();
        }

        private void AdditionStateOnUpdate()
        {
            if (!HasAdditionStates()) return;

            for (int i = 0; i < additionGameStates.Count; i++)
            {
                additionGameStates[i].OnUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (!HasCurrentState()) return;

            currentGameState.OnFixedUpdate();

            AdditionStateOnFixedUpdate();
        }

        private void AdditionStateOnFixedUpdate()
        {
            if (!HasAdditionStates()) return;

            for (int i = 0; i < additionGameStates.Count; i++)
            {
                additionGameStates[i].OnFixedUpdate();
            }
        }

        private bool HasCurrentState()
        {
            return currentGameState != null;
        }

        private bool HasAdditionStates()
        {
            return currentGameState.AdditionStatesOnStart.Count > 0;
        }
    }
}

