using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }
    public override void Enter()
    {
        _enemy._animator.SetBool("IsRunning", false);
    }
    public override void Update()
    {
        if (_enemy.IsPlayerInDetectionRange())
        {
            _stateMachine.ChangeState(new ChasingState(_enemy, _stateMachine));
            return;
        }
       //_enemy.SetAnimation("Idle");
    }
    public override void FixedUpdate() { }
    public override void Exit() 
    {
       
    }

}
