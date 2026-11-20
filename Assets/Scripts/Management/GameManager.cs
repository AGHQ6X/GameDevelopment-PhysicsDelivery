using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int targetScore = 3;
    public int startingAttempts = 3;

    public TMP_Text deliveriesText;
    public TMP_Text attemptsText;
    public TMP_Text statusText;
    public TMP_Text coinsText;

    protected int currentScore = 0;
    protected int currentAttempts;
    protected int currentCoins = 0;

    public bool isPlaying;

    public Transform resetObjectPosition;
    public Transform resetPointPosition;
    public Transform resetCameraPosition;

    public GameManager next;

    void Start()
    {
        currentAttempts = startingAttempts;

        statusText.text = "";

        if (isPlaying) Activate();
    }

    public void Activate()
    {
        isPlaying = true;

        GameObject.FindWithTag("GameController").GetComponent<ActiveManager>().active = this;

        GameObject.FindWithTag("ResetObject").transform.position = resetObjectPosition.position;
        GameObject.FindWithTag("ResetPoint").transform.position = resetPointPosition.position;

        GameObject.FindWithTag("Player").GetComponent<PlayerController>().ResetPlayer();
        GameObject.FindWithTag("DeliveryObject").GetComponent<DeliveryObject>().ResetDelivery();

        GameObject camera = GameObject.FindWithTag("MainCamera");
        camera.transform.position = resetCameraPosition.position;
        camera.transform.rotation = resetCameraPosition.rotation;

        UpdateUI();
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

    public virtual void AddCoins()
    {
        if (!isPlaying)
            return;

        currentCoins++;

        UpdateUI();
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

    protected virtual void UpdateUI()
    {
        deliveriesText.text =
            "Deliveries: " +
            currentScore +
            " / " +
            targetScore;

        attemptsText.text =
            "Attempts: " +
            currentAttempts;

        coinsText.text =
            "Coins: " +
            currentCoins;
    }

    void WinGame()
    {
        isPlaying = false;

        // No next level
        if (next == null)
        {
            statusText.text =
                "YOU WIN!";

            GameObject.FindWithTag("GameController").GetComponent<ActiveManager>().active = null;
        }
        // Move to next level
        else
        {
            next.Activate();
        }
    }

    void LoseGame()
    {
        isPlaying = false;

        statusText.text =
            "GAME OVER";

        GameObject.FindWithTag("GameController").GetComponent<ActiveManager>().active = null;
    }
}