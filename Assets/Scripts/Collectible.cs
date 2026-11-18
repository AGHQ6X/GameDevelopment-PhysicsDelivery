using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected!");
            gameManager.AddCoins();

            gameObject.SetActive(false);
        }
    }
}