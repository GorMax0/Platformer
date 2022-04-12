using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Button _restartButton;

    private void Awake()
    {
        _restartButton = GetComponentInChildren<Button>();
        _restartButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        _player.Death += EnableButton;
    }

    private void EnableButton()
    {
        _restartButton.onClick.AddListener(RestartLevel);
        _restartButton.gameObject.SetActive(true);
        _player.Death -= EnableButton;
    }

    private void RestartLevel()
    {
        _restartButton.onClick.RemoveListener(RestartLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
