using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _fulcrum;
    [SerializeField] private LayerMask _ground;

    private Player _player;
    private InputSystem _input;
    private PlayerAnimator _animation;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private float _groundCheckRadius = 0.1f;
    private bool _isFacingRight = true;
    private bool _canMove = true;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _input = new InputSystem();
        _animation = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.Player.Jump.performed += context => Jump();
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        _player.Died += DisallowMovement;
    }

    private void Update()
    {
        if (_direction.y != 0)
        {
            _animation.Jump(true);
        }
        else
        {
            _animation.Jump(false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _direction = new Vector2(_input.Player.Move.ReadValue<float>() * _speed, _rigidbody.velocity.y);

        bool isRunning = _direction.x != 0;

        if (_canMove)
        {
            _rigidbody.velocity = _direction;

            if (_direction.x < 0 && _isFacingRight == true)
            {
                Flip();
            }
            else if (_direction.x > 0 && _isFacingRight == false)
            {
                Flip();
            }

            _animation.Run(isRunning);
        }
    }

    private void Jump()
    {
        bool isGround = Physics2D.OverlapCircle(_fulcrum.position, _groundCheckRadius, _ground);

        if (isGround && _canMove)
        {
            _rigidbody.velocity = transform.up * _jumpForce;
        }
    }

    private void Flip()
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x *= -1;
        transform.localScale = tempScale;
        _isFacingRight = !_isFacingRight;
    }

    private void DisallowMovement()
    {
        _player.Died -= DisallowMovement;
        _canMove = false;
    }
}