using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UIHeart _heartTemplate;

    private int _currentHealth;
    private List<UIHeart> _healthPoints = new List<UIHeart>();

    private void OnEnable()
    {
        _player.HealthChange += OnHealthChange;
    }

    private void OnDisable()
    {
        _player.HealthChange -= OnHealthChange;
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
                if (TryFill(out UIHeart heart))
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
                if (TryEmpty(out UIHeart heart))
                {
                    heart.ToEmpty();
                }
            }
        }

        _currentHealth = health;
    }

    private UIHeart CreateHeart()
    {
        UIHeart heart = Instantiate(_heartTemplate, transform);

        return heart;
    }

    private bool TryFill(out UIHeart heart)
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

    private bool TryEmpty(out UIHeart heart)
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
