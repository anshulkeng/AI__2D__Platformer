using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 2f;
    public int damage = 20;
    public float attackCooldown = 0.4f;

    private float nextAttackTime = 0f;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("[PlayerAttack] NO Animator found on Player!");
        }
        else
        {
            Debug.Log("[PlayerAttack] Animator found. Ready to attack.");
        }
    }

    void Update()
    {
        // 1. Check key press
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("[PlayerAttack] F pressed");

            if (Time.time < nextAttackTime)
            {
                Debug.Log("[PlayerAttack] On cooldown, cannot attack yet.");
                return;
            }

            nextAttackTime = Time.time + attackCooldown;

            // 2. Trigger animation
            if (anim != null)
            {
                Debug.Log("[PlayerAttack] Calling anim.SetTrigger(\"Attack\")");
                anim.SetTrigger("Attack");
            }

            // 3. Apply damage
            DoDamage();
        }
    }

    void DoDamage()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            Debug.Log("[PlayerAttack] Distance to " + enemy.name + " = " + dist);

            if (dist <= attackRange)
            {
                ZombieHealth zh = enemy.GetComponent<ZombieHealth>();
                if (zh != null)
                {
                    zh.TakeDamage(damage);
                    Debug.Log("[PlayerAttack] HIT " + enemy.name + " for " + damage);
                }
                else
                {
                    Debug.LogWarning("[PlayerAttack] " + enemy.name + " has no ZombieHealth");
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
