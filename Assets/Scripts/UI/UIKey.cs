using UnityEngine;
using UnityEngine.UI;

public class UIKey : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Sprite _keyAvailable;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _player.KeyPurchased += DisplayKey;
    }

    private void OnDestroy()
    {
        _player.KeyPurchased -= DisplayKey;
    }

    private void DisplayKey()
    {
        _image.sprite = _keyAvailable;
    }
}
