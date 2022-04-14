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
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {        
        _player.Death += Die;
    }

    private void OnDisable()
    {
        _player.Death -= Die;
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