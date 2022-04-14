using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private int _amountCoins;
    private bool _isTakeCoin;

    public bool HasKey { get; private set; }

    public event UnityAction<bool> KeyIsAvailable;
    public event UnityAction Death;
    public event UnityAction<int> HealthChange;
    public event UnityAction<int> CoinPickup;

    private void Start()
    {
        HealthChange?.Invoke(_health);
    }

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

        if (collision.TryGetComponent(out Heart heart))
        {
            Destroy(heart.gameObject);
            _health += heart.Amount;
            HealthChange?.Invoke(_health);
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
            KeyIsAvailable?.Invoke(HasKey);
            return true;
        }

        return false;
    }

    public void UseKey()
    {
        HasKey = false;
        KeyIsAvailable?.Invoke(HasKey);
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