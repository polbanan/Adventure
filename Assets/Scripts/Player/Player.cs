using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerParam _playerParam;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _playerParam.ResetHealth();
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _playerParam.currentHealth -= damage;
        if (_playerParam.currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);        
    }
}
