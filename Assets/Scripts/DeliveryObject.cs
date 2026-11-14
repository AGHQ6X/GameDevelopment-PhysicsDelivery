using UnityEngine;

public class DeliveryObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ResetDelivery()
    {
        Transform resetPoint = GameObject.FindWithTag("ResetObject").GetComponent<Transform>();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.position = resetPoint.position;
        rb.rotation = resetPoint.rotation;
    }
}