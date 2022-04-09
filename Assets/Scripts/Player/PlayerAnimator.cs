using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsRunning = "isRunning";
    private const string IsJumping = "isJumping";
    private const string IsDead = "isDead";
    private Player _player;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        _player.OnDead += Die;
    }

    private void OnDestroy()
    {
        _player.OnDead -= Die;
    }

    public void Run(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }

    public void Jump(bool isJumping)
    {
        _animator.SetBool(IsJumping, isJumping);
    }

    public void Die()
    {
        _animator.SetBool(IsDead, true);
    }
}