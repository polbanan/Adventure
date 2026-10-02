using UnityEngine;

public class AttackingState: EnemyState
{
    private float _attackCooldown = 1f;
    private float _lastAttackTime;
    public AttackingState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }
    public override void Enter()
    {
        //Debug.Log("Enemy is attacking");
        _enemy._animator.SetTrigger("Hit");
        _lastAttackTime = Time.time - _attackCooldown; 
    }
    public override void Update()
    {
        if (!_enemy.IsPlayerInAttackRange())
        {
            _stateMachine.ChangeState(new ChasingState(_enemy, _stateMachine));
            return;
        }
        if (Time.time >= _lastAttackTime + _attackCooldown)
        {
            //_enemy.Attack();
            _lastAttackTime = Time.time;
        }
    }
    public override void FixedUpdate() { }
    public override void Exit() { }
}

