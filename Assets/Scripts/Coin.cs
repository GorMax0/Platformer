using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Drop()
    {
        //        transform.Translate(new Vector3(1f, 2f, 0));
        Debug.Log("Dropped!");
    }
}