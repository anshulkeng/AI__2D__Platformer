using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead = false;
    private Animator anim;

    void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

        Debug.Log("[PlayerHealth] Start HP: " + currentHealth);

        // Update HP UI at start (if UI exists)
        if (GameUIManager.Instance != null)
        {
            GameUIManager.Instance.UpdateHealth(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("[PlayerHealth] Took damage: " + amount + " | HP now: " + currentHealth);

        // Update UI
        if (GameUIManager.Instance != null)
        {
            GameUIManager.Instance.UpdateHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GetComponent<Animator>().SetBool("isDead", true);
            Debug.Log("PLAYER DIED!");
            // disable player controls after 1 sec
            Destroy(GetComponent<PlayerMovement>(), 1.0f);
            Destroy(GetComponent<PlayerAttack>(), 1.0f);
        }

    }

    public void RestoreHealth(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        Debug.Log("[PlayerHealth] Restored " + amount + " HP. Now: " + currentHealth);

        // Update UI
        if (GameUIManager.Instance != null)
        {
            GameUIManager.Instance.UpdateHealth(currentHealth, maxHealth);
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("[PlayerHealth] PLAYER DIED!");

        // 🔥 Play death animation
        if (anim != null)
        {
            anim.SetBool("isDead", true);   // MUST match Animator parameter name
        }

        // 🔥 Disable movement & attacks
        PlayerMovement move = GetComponent<PlayerMovement>();
        if (move != null) move.enabled = false;

        PlayerAttack attack = GetComponent<PlayerAttack>();
        if (attack != null) attack.enabled = false;

        // Optionally: also stop bat help etc. later if you want
    }
}
