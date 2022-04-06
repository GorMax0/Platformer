using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsRunning = "isRunning";
    private const string IsJumping = "isJumping";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }

    public void Jump(bool isJumping)
    {
        _animator.SetBool(IsJumping,isJumping);
    }
}
