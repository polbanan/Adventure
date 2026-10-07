using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerParam _playerParam;
    [SerializeField] private float attackRadius = 1f;
    private Enemy _enemy;
    private Animator _animator;
    private LayerMask _enemyLayer;
    private int _damage;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _enemyLayer = LayerMask.GetMask("Enemy");
        _damage = _playerParam.Damage;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _animator.SetTrigger("Attack");
            Collider2D[] hitEnemyes = Physics2D.OverlapCircleAll(transform.position, attackRadius, _enemyLayer);
            Debug.Log("Player Attack");
            if (hitEnemyes.Length > 0)
            {
                Attack(hitEnemyes);
            }
        }
    }
    private void Attack(Collider2D[] hitEnemyes)
    {
        foreach (var col in hitEnemyes)
        {
            var enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
        Gizmos.DrawSphere(transform.position, attackRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius); // Просто для визуализации радиуса атаки в редакторе
    }

}
