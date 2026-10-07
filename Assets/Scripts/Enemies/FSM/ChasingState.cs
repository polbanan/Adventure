using UnityEngine;

public class ChasingState : EnemyState
{
    public ChasingState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }
    public override void Enter()
    {
        //Debug.Log("Enemy is Chase");
        _enemy._animator.SetBool("IsRunning", true);
    }

    public override void Update()
    {
        if (!_enemy.IsPlayerInDetectionRange())
        {
            _stateMachine.ChangeState(new IdleState(_enemy, _stateMachine));
            return;
        }

        _enemy.MoveTowardsPlayer();

    }

    public override void FixedUpdate() { }

    public override void Exit() 
    { 
        _enemy._animator.SetBool("IsRunning", false);
        _enemy._rb.linearVelocity = Vector2.zero;
    }
}


