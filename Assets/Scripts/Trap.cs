using UnityEngine;

public class Trap : MonoBehaviour
{
    private int _damage = 999;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}
