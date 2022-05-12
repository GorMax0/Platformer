using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDeathEffect _deathEffect;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private int _damage = 1;

    private Coroutine _causeDamage;

    public event UnityAction CollisionToPlayerDetected
        ;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _causeDamage = StartCoroutine(CauseDamage(player));
        }

        CollisionToPlayerDetected?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            StopCoroutine(_causeDamage);
            _causeDamage = null;
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

        while (true)
        {
            player.TakeDamage(_damage);
            yield return waitForSeconds;
        }
    }
}
