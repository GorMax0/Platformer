using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class Restart : MonoBehaviour
{
    [SerializeField] private Player _player;

    private CanvasGroup _restartPanel;
    private Button _restartButton;

    private void Awake()
    {
        _restartPanel = GetComponent<CanvasGroup>();
        _restartButton = GetComponentInChildren<Button>();
        _restartPanel.alpha = 0f;
    }

    private void OnEnable()
    {
        _player.Death += OnDeath;
        _restartButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _player.Death -= OnDeath;
        _restartButton.onClick.RemoveListener(RestartLevel);
    }

    private void OnDeath()
    {
        _restartPanel.alpha = 1f;
    }

    private void RestartLevel()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
