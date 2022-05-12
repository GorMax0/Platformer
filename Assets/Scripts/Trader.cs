using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] private Dialog _dialog;
    [SerializeField] private Key _key;

    private string _message;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player.Key == null)
            {
                if (_key.Cost <= player.Coins)
                {
                    player.BuyKey(_key);
                    _message = "Вижу ты принес мне монеты, держи ключ! Надеюсь он поможет открыть тебе дверь... Хе-хе-хе...";
                }
                else
                {
                    _message = $"У меня есть то, что поможет открыть дверь, приниси мне {_key.Cost} монет и я отдам тебе {_key.Name}!";
                }
            }
            else
            {
                _message = "Я тебе уже продал ключ, чего тебе ещё нужно?!";
            }

            _dialog.ShowDialog(_message);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _dialog.HideDialog();
        }
    }
}
