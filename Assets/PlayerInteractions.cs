using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public int coins = 0;
    private PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();

        // Show starting UI values
        if (GameUIManager.Instance != null)
        {
            GameUIManager.Instance.UpdateCoins(coins);
            GameUIManager.Instance.UpdateHealth(playerHealth.currentHealth, playerHealth.maxHealth);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger with: " + other.tag);

        // COIN PICKUP
        if (other.CompareTag("Coin"))
        {
            coins++;
            Debug.Log("Coins Collected: " + coins);
            Destroy(other.gameObject);

            // Update UI text immediately
            if (GameUIManager.Instance != null)
                GameUIManager.Instance.UpdateCoins(coins);
        }


        // HEALTH PICKUP DROPPED FROM ZOMBIE
        else if (other.CompareTag("HealthPickup"))
        {
            if (playerHealth != null)
            {
                playerHealth.RestoreHealth(20); // +20 HP
                Debug.Log("❤️ Player healed +20 HP");
            }

            Destroy(other.gameObject);
        }
    }
}
