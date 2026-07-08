using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    [Header("UI Texts")]
    public TMP_Text healthText;
    public TMP_Text coinsText;

    private void Awake()
    {
        // Singleton so other scripts can use GameUIManager.Instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealth(int current, int max)
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + current + " / " + max;
        }
    }

    public void UpdateCoins(int coins)
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coins;
        }
    }
}
