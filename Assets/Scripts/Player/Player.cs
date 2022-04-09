using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private int _amountCoins;

    public UnityAction OnDead;
    public UnityAction<int> OnChangeHealth;
    public UnityAction<int> OnPickupCoin;

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
            OnPickupCoin?.Invoke(_amountCoins);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        OnChangeHealth?.Invoke(_health);

        if(_health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}