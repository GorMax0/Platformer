using UnityEngine;
using UnityEngine.UI;

public class CoinsView : MonoBehaviour
{
   [SerializeField] private Player _player;

    private Text _countCoins;    

    private void Awake()
    {
        _countCoins = GetComponentInChildren<Text>();
    }

    private void Start()
    {   
        _player.AmountCoinChanged += CountCoins;
    }

    private void OnDestroy()
    {
        _player.AmountCoinChanged -= CountCoins;
    }

    private void CountCoins(int countCoin)
    {
        _countCoins.text = $": {countCoin}";
    }
}
