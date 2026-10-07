using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        _animator.SetBool(IS_RUNNING, PlayerConrtoller.Instance.IsRunning());
        _animator.SetFloat("InputX", PlayerConrtoller.Instance.GetLastDirection().x);
        _animator.SetFloat("InputY", PlayerConrtoller.Instance.GetLastDirection().y);
    }
}
