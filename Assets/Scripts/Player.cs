using UnityEngine;
public class Player : MonoBehaviour
{
    private int _health = 3;

    private void TakeDamage()
    {
        int damage = 1;

        _health -= damage;
        Debug.Log(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.Destroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            TakeDamage();
        }
    }
}