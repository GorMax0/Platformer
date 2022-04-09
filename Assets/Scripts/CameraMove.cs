using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offsetLeft = 3.5f;
    [SerializeField] private float _offsetRight = 29.55f;

    private void FixedUpdate()
    {
        FollowPlayer();    
    }

    private void FollowPlayer()
    {
        if (_player != null)
        {            
            float positionX = Mathf.Clamp(_player.transform.position.x, _offsetLeft, _offsetRight);

            transform.position = new Vector3(positionX, 0, transform.position.z);
        }
    }
}
