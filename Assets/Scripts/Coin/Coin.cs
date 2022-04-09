using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    public void Drop()
    {
        StartCoroutine(Scatter());
    }

    private IEnumerator Scatter()
    {
        float speed = 6f;
        float scatterTime = 0.5f;
        float pastTime = 0f;
        float minPositionX = -0.15f;
        float maxPositionX = 0.15f;
        float minPositionY = 0f;
        float maxPositionY = 0.3f;
        float offsetX = Random.Range(minPositionX, maxPositionX);
        float offsetY = Random.Range(minPositionY, maxPositionY);
        Vector3 direction = new Vector3(offsetX, offsetY, transform.position.z);
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        while (pastTime <= scatterTime)
        {
            transform.position += direction * speed * Time.deltaTime;
            pastTime += Time.deltaTime;

            yield return waitForEndOfFrame;
        }

        yield return waitForEndOfFrame;
        AllowPickup();
    }

    private void AllowPickup()
    {
        _circleCollider.enabled = true;
    }
}