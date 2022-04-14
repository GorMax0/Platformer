using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIHeart : MonoBehaviour
{
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _emptyHeart;

    private Image _image;

    public bool IsFull { get; private set; } = true;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ToFill()
    {
        _image.sprite = _fullHeart;
        IsFull = true;
    }

    public void ToEmpty()
    {
        _image.sprite = _emptyHeart;
        IsFull = false;
    }
}
