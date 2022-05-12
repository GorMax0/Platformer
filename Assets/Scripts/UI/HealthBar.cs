using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HeartView _heartTemplate;

    private int _currentHealth;
    private List<HeartView> _healthPoints = new List<HeartView>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChange;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChange;
    }

    private void OnHealthChange(int health)
    {
        if (_healthPoints.Count == 0)
        {
            for (int i = 0; i < health; i++)
            {
                _healthPoints.Add(CreateHeart());
            }
        }
        else if (_currentHealth < health)
        {
            for (int i = 0; i < health - _currentHealth; i++)
            {
                if (TryFill(out HeartView heart))
                {
                    heart.ToFill();
                }
                else
                {
                    _healthPoints.Add(CreateHeart());
                }
            }
        }
        else if (_currentHealth > health)
        {
            for (int i = 0; i < _currentHealth - health; i++)
            {
                if (TryEmpty(out HeartView heart))
                {
                    heart.ToEmpty();
                }
            }
        }

        _currentHealth = health;
    }

    private HeartView CreateHeart()
    {
        HeartView heart = Instantiate(_heartTemplate, transform);

        return heart;
    }

    private bool TryFill(out HeartView heart)
    {
        for (int i = 0; i < _healthPoints.Count; i++)
        {
            if (_healthPoints[i].IsFull == false)
            {
                heart = _healthPoints[i];
                return true;
            }
        }

        heart = null;
        return false;
    }

    private bool TryEmpty(out HeartView heart)
    {
        for (int i = _healthPoints.Count - 1; i >= 0; i--)
        {
            if (_healthPoints[i].IsFull == true)
            {
                heart = _healthPoints[i];
                return true;
            }
        }

        heart = null;
        return false;
    }
}
