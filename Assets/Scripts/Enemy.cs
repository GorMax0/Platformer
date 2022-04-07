using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem _deathEffect;

    private void Start()
    {
        _deathEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void Destroy()
    {        
        _deathEffect.Play();
        Destroy(gameObject, 3f);
    }
}
