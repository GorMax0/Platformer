using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _emptyHeart;

    private Image[] _healthPoint;

    private void Awake()
    {
        _healthPoint = GetComponentsInChildren<Image>();
    }

    private void Start()
    {
        _player.OnChangeHealth += CountHealth;
    }

    private void CountHealth(int health)
    {
        for (int i = 0; i < _healthPoint.Length; i++)
        {
            if (i >= health)
            {
                _healthPoint[i].sprite = _emptyHeart;
            }
        }
    }
}
