using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _fulcrum;
    [SerializeField] private LayerMask _ground;

    private Player _player;
    private PlayerAnimator _animation;
    private Rigidbody2D _rigidbody;
    private float _groundCheckRadius = 0.1f;
    private bool _isFacingRight = true;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animation = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _player.OnDead += Destroy;
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontalMove * _speed, _rigidbody.velocity.y);
        bool isRunning = horizontalMove != 0;

        _rigidbody.velocity = direction;

        if (horizontalMove < 0 && _isFacingRight == true)
        {
            Flip();
        }
        else if (horizontalMove > 0 && _isFacingRight == false)
        {
            Flip();
        }

        _animation.Run(isRunning);
    }

    private void Jump()
    {
        bool isJump = Input.GetButtonDown("Jump");
        bool isGround = Physics2D.OverlapCircle(_fulcrum.position, _groundCheckRadius, _ground);

        if (isJump && isGround)
        {
            _rigidbody.velocity = transform.up * _jumpForce;
        }

        _animation.Jump(!isGround);
    }

    private void Flip()
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x *= -1;
        transform.localScale = tempScale;
        _isFacingRight = !_isFacingRight;
    }

    private void Destroy()
    {
        _player.OnDead -= Destroy;
        Destroy(this, 0.1f);
    }
}
