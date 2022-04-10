using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private int _amountCoins;

    public UnityAction Death;
    public UnityAction<int> HealthChange;
    public UnityAction<int> CoinPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            _amountCoins++;
            Destroy(coin.gameObject);
            CoinPickup?.Invoke(_amountCoins);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChange?.Invoke(_health);

        if(_health <= 0)
        {
            Death?.Invoke();
        }
    }
}