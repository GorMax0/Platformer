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
                    _message = "���� �� ������ ��� ������, ����� ����! ������� �� ������� ������� ���� �����... ��-��-��...";
                }
                else
                {
                    _message = "� ���� ���� ��, ��� ������� ������� �����, ������� ��� 50 ����� � � ����� ���� ����!";
                }
            }
            else
            {
                _message = "� ���� ��� ������ ����, ���� ���� ��� �����?!";
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
