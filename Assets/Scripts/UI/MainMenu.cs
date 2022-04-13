using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _levelScene = 1;
    private Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();
    }

    private void Start()
    {
        _buttons[0].onClick.AddListener(StartGame);
        _buttons[2].onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        foreach (var button in _buttons)
        {
            button.onClick.RemoveAllListeners();
        }

        SceneManager.LoadScene(_levelScene);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
