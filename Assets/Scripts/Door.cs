using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
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
            if (player.Key != null)
            {
                Open(player);
            }
            else
            {
                _message = "Нужен ключ, чтобы открыть дверь!";
                _dialog.ShowDialog(_message);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _dialog.HideDialog();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _message = "ПОЗДРАВЛЯЮ УРОВЕНЬ ПРОЙДЕН!";
            _dialog.ShowDialog(_message);
        }
    }

    private void Open(Player player)
    {
        player.UseKey();
        _doorSprite.sprite = _doorOpen;
        _collider.isTrigger = true;
    }
}
