using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }
    public override void Enter()
    {
        Debug.Log("Enemy is idle");
        _enemy.SetAnimation("Idle");
    }
    public override void Update()
    {
        if (_enemy.IsPlayerInDetectionRange())
        {
            _stateMachine.ChangeState(new ChasingState(_enemy, _stateMachine));
            return;
        }
       
    }
    public override void FixedUpdate() { }
    public override void Exit() { }

}
