using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private bool _isTakeCoin;

    public int Coins { get; private set; }
    public Key Key { get; private set; }

    public event UnityAction Died;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> AmountCoinChanged;
    public event UnityAction<Key> KeyBuyed;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
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
                Coins++;
                AmountCoinChanged?.Invoke(Coins);
            }
        }

        if (collision.TryGetComponent(out Heart heart))
        {
            Destroy(heart.gameObject);
            _health += heart.Amount;
            HealthChanged?.Invoke(_health);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _isTakeCoin = false;
        }
    }

    public void BuyKey(Key key)
    {
        Coins -= key.Cost;
        Key = key;
        KeyBuyed?.Invoke(Key);
        AmountCoinChanged?.Invoke(Coins);
    }

    public void UseKey()
    {
        Key = null;
        KeyBuyed?.Invoke(Key);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Died?.Invoke();
        }
    }
}