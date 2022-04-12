using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private int _amountCoins;
    private bool _isTakeCoin;

    public bool HasKey { get; private set; }

    public event UnityAction KeyPurchased;
    public event UnityAction Death;
    public event UnityAction<int> HealthChange;
    public event UnityAction<int> CoinPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);

            if (_isTakeCoin == false)
            {
                _isTakeCoin = true;
                _amountCoins++;
                CoinPickup?.Invoke(_amountCoins);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _isTakeCoin = false;
        }
    }

    public bool TryBuyKey(int cost)
    {
        if (_amountCoins >= cost)
        {
            _amountCoins -= cost;
            HasKey = true;
            KeyPurchased?.Invoke();
            return true;
        }

        return false;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChange?.Invoke(_health);

        if (_health <= 0)
        {
            Death?.Invoke();
        }
    }
}