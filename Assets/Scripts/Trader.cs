using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] private Dialog _dialog;

    private string _message;
    private int _costKey = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player.HasKey == false)
            {
                if (player.TryBuyKey(_costKey))
                {
                    _message = "Вижу ты принес мне монеты, держи ключ! Надеюсь он поможет открыть тебе дверь... Хе-хе-хе...";
                }
                else
                {
                    _message = "У меня есть то, что поможет открыть дверь, приниси мне 50 монет и я отдам тебе ключ!";
                }
            }
            else
            {
                _message = "Я тебе уже продал ключ, чего тебе ещё нужно?!";
            }

            _dialog.ShowDialog(true, _message);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _dialog.ShowDialog(false);
        }
    }
}
