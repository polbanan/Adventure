using UnityEngine;

public class EnemyState: IState
{
    protected readonly Enemy _enemy;
    protected readonly StateMachine _stateMachine;

    public EnemyState(Enemy enemy, StateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}
