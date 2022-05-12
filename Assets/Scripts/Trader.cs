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
                    _message = "���� �� ������ ��� ������, ����� ����! ������� �� ������� ������� ���� �����... ��-��-��...";
                }
                else
                {
                    _message = $"� ���� ���� ��, ��� ������� ������� �����, ������� ��� {_key.Cost} ����� � � ����� ���� {_key.Name}!";
                }
            }
            else
            {
                _message = "� ���� ��� ������ ����, ���� ���� ��� �����?!";
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
