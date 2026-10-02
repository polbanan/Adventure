using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    // Параметры врага
    private float _detectionRange = 2f;
    private float _attackRange = 1f;
    private float _chaseSpeed = 3f;
    private float _idleSpeed = 1f;

    // Слой врага
    [SerializeField] private LayerMask playerLayer;
    private Animator _animator;
    private Rigidbody2D _rb;


    // FSM
    private StateMachine _stateMachine;
    private EnemyState _enemyState { get; set; }
    private IdleState _idleState { get; set; }
    public ChasingState _chasingState { get; set; }


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _stateMachine = new StateMachine();

        _enemyState = new EnemyState(this, _stateMachine);
        _idleState = new IdleState(this, _stateMachine);
        _chasingState = new ChasingState(this, _stateMachine);

        // Инициализируем StateMachine с начальным состоянием
        _stateMachine.Initialized(_idleState);
        Debug.Log("Enemy FSM initialized with IdleState");
    }
    public void SetAnimation(string animationName)
    {
        _animator.Play(animationName);
    }

    public bool IsPlayerInDetectionRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return false;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= _detectionRange;
    }

    public bool IsPlayerInAttackRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return false;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= _attackRange;
    }

    public void MoveTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) { 
        Vector2 direction = (player.transform.position - transform.position).normalized;
            _rb.linearVelocity = direction * _chaseSpeed;
        }
    }
    void Update()
    {
        _stateMachine.Update();
    }
}
