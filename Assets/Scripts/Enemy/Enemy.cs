using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDeathEffect _deathEffect;
    [SerializeField] private CoinSpawner _coinSpawner;

    private bool _isPlayerCollision;

    private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _isPlayerCollision = true;
            StartCoroutine(CauseDamage(player));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _isPlayerCollision = false;
        }
    }

    public void Destroy()
    {
        _deathEffect.InvokEffect(transform);
        _coinSpawner.DropCoins(transform);
        Destroy(gameObject);
    }

    private IEnumerator CauseDamage(Player player)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1f);

        while (_isPlayerCollision)
        {
            player.TakeDamage(_damage);
            yield return waitForSeconds;
        }
    }
}
