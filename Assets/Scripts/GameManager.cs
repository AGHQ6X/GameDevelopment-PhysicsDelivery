using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int targetScore = 3;
    public int startingAttempts = 3;

    public TMP_Text deliveriesText;
    public TMP_Text attemptsText;
    public TMP_Text statusText;

    private int currentScore = 0;
    private int currentAttempts;

    public bool isPlaying;

    public Transform resetObjectPosition;
    public Transform resetPointPosition;
    public Transform resetCameraPosition;

    public GameManager next;

    void Start()
    {
        currentAttempts = startingAttempts;

        UpdateUI();

        statusText.text = "";

        if (isPlaying) Activate();
    }

    public void Activate()
    {
        GameObject.FindWithTag("ResetObject").transform.position = resetObjectPosition.position;
        GameObject.FindWithTag("ResetPoint").transform.position = resetPointPosition.position;

        GameObject.FindWithTag("Player").GetComponent<PlayerController>().ResetPlayer();
        GameObject.FindWithTag("DeliveryObject").GetComponent<DeliveryObject>().ResetDelivery();

        GameObject camera = GameObject.FindWithTag("MainCamera");
        camera.transform.position = resetCameraPosition.position;
        camera.transform.rotation = resetCameraPosition.rotation;
    }

    public void AddScore()
    {
        if (!isPlaying)
            return;

        currentScore++;

        UpdateUI();

        if (currentScore >= targetScore)
        {
            WinGame();
        }
    }

    public void LoseAttempt()
    {
        if (!isPlaying)
            return;

        currentAttempts--;

        UpdateUI();

        if (currentAttempts <= 0)
        {
            LoseGame();
        }
    }

    void UpdateUI()
    {
        deliveriesText.text =
            "Deliveries: " +
            currentScore +
            " / " +
            targetScore;

        attemptsText.text =
            "Attempts: " +
            currentAttempts;
    }

    void WinGame()
    {
        isPlaying = false;

        statusText.text =
            "YOU WIN!";
    }

    void LoseGame()
    {
        isPlaying = false;

        statusText.text =
            "GAME OVER";
    }
}