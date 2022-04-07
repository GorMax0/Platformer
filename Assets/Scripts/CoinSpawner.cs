using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private SpawnPointCoin[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPointCoin>();
        Spawn();
    }

    private void Spawn()
    {
        float minRandomValue = -0.3f;
        float maxRandomValue = 0.3f;

        foreach (var spawnPoint in _spawnPoints)
        {
            float randomOffsetX = Random.Range(minRandomValue, maxRandomValue);
            float randomOffsetY = Random.Range(minRandomValue, maxRandomValue);
            float spawnPositionX = spawnPoint.transform.position.x + randomOffsetX;
            float spawnPositionY = spawnPoint.transform.position.y + randomOffsetY;

            Instantiate(_coin, new Vector2(spawnPositionX, spawnPositionY), Quaternion.identity);
        }
    }

    public void DropCoins(Transform enemy)
    {
        int minCount = 3;
        int maxCount = 7;
        int countCoin = Random.Range(minCount, maxCount);

        for (int i = 0; i < countCoin; i++)
        {
            Coin coin = Instantiate(_coin, enemy.transform.position, Quaternion.identity);
            coin.Drop();
        }
    }
}
