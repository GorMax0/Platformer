using System.Collections;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    [SerializeField] private float _limitUp;
    [SerializeField] private float _limitDown;
    [SerializeField] private float _speed = 1f;

    private bool _isUpwardMove = true;

    private void FixedUpdate()
    {
        Vector2 direction = _isUpwardMove ? new Vector2(transform.position.x, _limitUp) : new Vector2(transform.position.x, _limitDown);

        transform.position = Vector2.MoveTowards(transform.position, direction, _speed * Time.fixedDeltaTime);

        if (transform.position.y >= _limitUp)
        {
            _isUpwardMove = false;
        }
        else if (transform.position.y <= _limitDown)
        {
            _isUpwardMove = true;
        }
    }
}
