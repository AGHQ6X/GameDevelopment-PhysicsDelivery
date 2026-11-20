using UnityEngine;

public class HazardZone : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeliveryObject"))
        {
            gameManager.LoseAttempt();

            DeliveryObject delivery =
                other.GetComponent<DeliveryObject>();

            if (delivery != null &&
                gameManager.isPlaying)
            {
                delivery.ResetDelivery();
            }
        }
    }
}