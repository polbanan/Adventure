using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public void Initialized(IState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(IState newState)
    {
        Debug.Log($"{CurrentState}");
        CurrentState?.Exit();
        CurrentState = newState;
        Debug.Log($"{CurrentState}");
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }
}
