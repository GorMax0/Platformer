using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] private float _parallaxStrength;

    private Vector3 _targetPreviousPosition;

    private void Start()
    {
        if (_followingTarget == null)
        {
            _followingTarget = Camera.main.transform;
        }

        _targetPreviousPosition = _followingTarget.position;
    }

    private void Update()
    {
        Vector3 delta = _followingTarget.position - _targetPreviousPosition;

        _targetPreviousPosition = _followingTarget.position;
        transform.position += delta * _parallaxStrength;
    }
}
