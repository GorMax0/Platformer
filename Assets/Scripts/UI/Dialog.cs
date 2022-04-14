using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Dialog : MonoBehaviour
{
    private CanvasGroup _dialog;
    private Text _messege;

    private void Awake()
    {
        _dialog = GetComponent<CanvasGroup>();
        _messege = GetComponentInChildren<Text>();
        _dialog.alpha = 0f;
    }

    public void ShowDialog(string message)
    {
        _dialog.alpha = 1f;
        _messege.text = message;
    }

    public void HideDialog()
    {
        _dialog.alpha = 0f;
    }
}
