using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 50;
    int currentHealth;

    public GameObject healthPickupPrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log("[ZombieHealth] Zombie took " + dmg + " damage. HP = " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
        currentHealth = maxHealth;
    }

    void Die()
    {
        Debug.Log("[ZombieHealth] ZOMBIE DIED!");

        if (healthPickupPrefab != null)
        {
            Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);
            Debug.Log("💊 Health Dropped!");
        }
        else
        {
            Debug.LogWarning("⚠ No Health Prefab Assigned!");
        }

        Destroy(gameObject);
    }
}
