using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeliveryObject"))
        {
            gameManager.AddScore();

            DeliveryObject delivery =
                other.GetComponent<DeliveryObject>();

            if (delivery != null)
            {
                delivery.ResetDelivery();
            }
        }
    }
}