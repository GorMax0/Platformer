using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDeathEffect _deathEffect;
    [SerializeField] private CoinSpawner _coinSpawner;

    public void Destroy()
    {
        _deathEffect.InvokEffect(transform);
        _coinSpawner.DropCoins(transform);
        Destroy(gameObject);
    }
}
