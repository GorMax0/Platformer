using UnityEngine;
using UnityEngine.UI;

public class UICoins : MonoBehaviour
{
   [SerializeField] private Player _player;

    private Text _countCoins;    

    private void Awake()
    {
        _countCoins = GetComponentInChildren<Text>();
    }

    private void Start()
    {   
        _player.CoinPickup += CountCoins;
    }

    private void OnDestroy()
    {
        _player.CoinPickup -= CountCoins;
    }

    private void CountCoins(int countCoin)
    {
        _countCoins.text = $": {countCoin}";
    }
}
