using UnityEngine;

public class TriggerSink : Triggerable
{
    public float moveSpeed = 0.5f;

    void Update()
    {
        if (transform.position.y < -5f)
            gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isTriggered)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }
}
