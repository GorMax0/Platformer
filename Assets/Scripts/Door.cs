using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Dialog _dialog;
    [SerializeField] private Sprite _doorOpen;

    private SpriteRenderer _doorSprite;
    private BoxCollider2D _collider;
    private string _message;

    private void Awake()
    {
        _doorSprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (player.HasKey)
            {
                player.UseKey();
                _doorSprite.sprite = _doorOpen;
                _collider.isTrigger = true;
            }
            else
            {
                _message = "Нужен ключ, чтобы открыть дверь!";
                _dialog.ShowDialog(true, _message);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _dialog.ShowDialog(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _message = "ПОЗДРАВЛЯЮ УРОВЕНЬ ПРОЙДЕН!";
            _dialog.ShowDialog(true, _message);
        }
    }
}
