using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        Spawn();
    }

    public void DropCoins(Transform enemy)
    {
        int minCount = 3;
        int maxCount = 7;
        int countCoin = Random.Range(minCount, maxCount);

        for (int i = 0; i < countCoin; i++)
        {
            Coin coin = Instantiate(_coin, enemy.transform.position, Quaternion.identity, transform);
            coin.Drop();            
        }
    }

    private void Spawn()
    {
        Coin coin;

        foreach (var spawnPoint in _spawnPoints)
        {
            float spawnPositionX = spawnPoint.transform.position.x;
            float spawnPositionY = spawnPoint.transform.position.y;

            coin = Instantiate(_coin, new Vector2(spawnPositionX, spawnPositionY), Quaternion.identity, transform);
            coin.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
