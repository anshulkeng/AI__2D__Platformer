using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.RestoreHealth(healAmount);
                Debug.Log("❤️ Player healed +" + healAmount);
            }
            Destroy(gameObject);
        }
    }
}
