using UnityEngine;

public class TriggerSink : Triggerable
{
    void Update()
    {
        if (rb.transform.position.y < 5f)
            gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isTriggered)
        {
            transform.position -= Time.deltaTime;
        }
    }

    protected override void Activate()
    {

    }
}
