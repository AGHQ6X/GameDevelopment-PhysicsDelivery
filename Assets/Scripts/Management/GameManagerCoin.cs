using UnityEngine;

public class GameManagerCoin : GameManager
{
    public int targetCoins = 3;

    public Triggerable trigger;

    public override void AddCoins()
    {
        if (!isPlaying)
            return;

        currentCoins++;

        UpdateUI();

        if (currentCoins >= targetCoins && trigger != null)
        {
            trigger.Trigger();
        }
    }

    protected override void UpdateUI()
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
            currentCoins +
            " / " +
            targetCoins;
    }
}
