using UnityEngine;

public class MiniGolem : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Animator _animator;
    private bool _isRunning = false;
    public bool IsRunning()
    {
        return _isRunning;
    }
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
