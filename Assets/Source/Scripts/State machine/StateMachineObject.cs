using System;
using NaughtyAttributes;
using UnityEngine;

public abstract class StateMachineObject<T>  : MonoBehaviour where T : Enum
{
    protected StateMachine<T> StateMachine { get; } = new StateMachine<T>();

    [Header("DEBUG")]
    [SerializeField, ReadOnly] protected T currentState;

    protected bool isEnabled;

    private void OnEnable()
    {
        if (!isEnabled)
        {
            GetComponents();

            Init();

            LoadStates();

            StateMachine.OnStateChange += type => currentState = type;
        }

        SetInitialState();

        isEnabled = true;
    }

    protected abstract void SetInitialState();
    protected abstract void GetComponents();
    protected abstract void Init();
    protected abstract void LoadStates();

    private void Update()
    {
        StateMachine.Tick();
    }
}
