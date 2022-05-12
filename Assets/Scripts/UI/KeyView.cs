using UnityEngine;
using UnityEngine.UI;

public class KeyView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Sprite _noKey;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _player.KeyBuyed += DisplayKey;
    }

    private void OnDisable()
    {
        _player.KeyBuyed -= DisplayKey;
    }

    private void DisplayKey(Key key)
    {
        if (key != null)
        {
            _image.sprite = key.Icon;
        }
        else
        {
            _image.sprite = _noKey;
        }
    }
}
