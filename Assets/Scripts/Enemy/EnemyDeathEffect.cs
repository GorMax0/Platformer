using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private List<ParticleSystem> _deathEffects = new List<ParticleSystem>();

    private void Awake()
    {
        FillDeathEffects();
    }

    public void InvokEffect(Transform enemy)
    {
        ParticleSystem effect = GetFreeEffect();

        effect.transform.position = enemy.position;
        effect.gameObject.SetActive(true);
    }

    private void FillDeathEffects()
    {
        int defaultCount = 3;

        for (int i = 0; i < defaultCount; i++)
        {
            CreateEffect();
        }
    }

    private ParticleSystem CreateEffect()
    {
        ParticleSystem effect = Instantiate(_particle, transform);

        _deathEffects.Add(effect);

        return effect;
    }

    private ParticleSystem GetFreeEffect()
    {
        foreach (var effect in _deathEffects)
        {
            if (effect.gameObject.activeInHierarchy == false)
            {
                return effect;
            }
        }

        return CreateEffect();
    }
}
