using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] Transform _platformDetector;

    private Rigidbody2D _rigidbody;
    private Vector2 _directon;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _directon = new Vector2(_speed, _rigidbody.velocity.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = _directon;
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        float distance = 0.53f;
        var obstacleInFront = Physics2D.Raycast(transform.position, transform.right * transform.localScale.x, distance, _layerGround);
        var platformPresence = Physics2D.Raycast(_platformDetector.position, -_platformDetector.up, distance, _layerGround);

        if (obstacleInFront.collider != null)
        {
            Flip();
            _directon = -_directon;
        }
        else if (platformPresence.collider == null)
        {
            Flip();
            _directon = -_directon;
        }
    }

    private void Flip()
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
