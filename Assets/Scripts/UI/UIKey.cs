using UnityEngine;
using UnityEngine.UI;

public class UIKey : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Sprite _keyAvailable;
    [SerializeField] private Sprite _noKey;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _player.KeyIsAvailable += DisplayKey;
    }

    private void OnDestroy()
    {
        _player.KeyIsAvailable -= DisplayKey;
    }

    private void DisplayKey(bool hasKey)
    {
        if (hasKey)
        {
            _image.sprite = _keyAvailable;
        }
        else
        {
            _image.sprite = _noKey;
        }
    }
}
