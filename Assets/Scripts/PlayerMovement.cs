using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;
    private bool _isGround = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction;
        var horizontalMove = Input.GetAxisRaw("Horizontal");
        var isJump = Input.GetButtonDown("Jump");       
        
        if (horizontalMove < 0 && _isFacingRight == true)
        {
            Flip();
        }
        else if (horizontalMove > 0 && _isFacingRight == false)
        {
            Flip();
        }

        direction = new Vector2(horizontalMove * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = direction;

        if(isJump && _isGround)
        {
            _isGround = false;
            _rigidbody.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        Vector3 tempScale;

        _isFacingRight = !_isFacingRight;
        tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
}
