using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private Image _background;
    private Text _messege;

    private void Awake()
    {
        _background = GetComponentInChildren<Image>();
        _messege = GetComponentInChildren<Text>();
        ShowDialog(false);
    }

    public void ShowDialog(bool isEnable, string message = "")
    {
        _background.gameObject.SetActive(isEnable);
        _messege.gameObject.SetActive(isEnable);
        _messege.text = message;
    }
}
