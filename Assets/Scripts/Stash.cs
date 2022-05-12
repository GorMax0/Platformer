using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stash : MonoBehaviour
{
    private const float NotTransparent = 1f;
    private const float HalfTransparent = 0.5f;
    private float _currentTransparency = 1f;
    private Tilemap _tilemap;
    private Coroutine _changeTransparency;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_changeTransparency != null)
            {
                StopCoroutine(_changeTransparency);
                _changeTransparency = null;
            }

            _changeTransparency = StartCoroutine(ChangeTransparency(HalfTransparent));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_changeTransparency != null)
            {
                StopCoroutine(_changeTransparency);
                _changeTransparency = null;
            }

            _changeTransparency = StartCoroutine(ChangeTransparency(NotTransparent));
        }
    }

    private IEnumerator ChangeTransparency(float targetTransparency)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.05f);
        float step = 0.1f;

        while (_currentTransparency != targetTransparency)
        {
            _currentTransparency = Mathf.MoveTowards(_currentTransparency, targetTransparency, step);
            _tilemap.color = new Color(1f, 1f, 1f, _currentTransparency);

            yield return waitForSeconds;
        }

        _changeTransparency = null;
    }
}
