using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ZombieAI : MonoBehaviour
{
    [Header("Movement")]
    public Transform player;       // player to chase
    public float speed = 2f;       // walk speed

    [Header("Zombie damages player")]
    public float attackCooldown = 1f;  // seconds between hits
    public int attackDamage = 10;      // damage TO player 

    [Header("Player damages zombie")]
    public int damageFromPlayer = 25;  // damage when player presses F

    private float lastAttackTime = 0f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // auto find player if not set in Inspector
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
            else
                Debug.LogError("[ZombieAI] Player with tag 'Player' not found!");
        }
    }

    void Update()
    {
        if (player == null) return;

        // simple move towards player on X
        Vector2 pos = rb.position;
        float dir = Mathf.Sign(player.position.x - pos.x);
        rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // ---- 1. ZOMBIE HITS PLAYER (cooldown) ----
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(attackDamage);
                Debug.Log("[ZombieAI] Trigger hit player, dealing damage: " + attackDamage);
            }
        }

        // ---- 2. PLAYER HITS ZOMBIE WITH F ----
        if (Input.GetKeyDown(KeyCode.F))
        {
            ZombieHealth zh = GetComponent<ZombieHealth>();
            if (zh != null)
            {
                Debug.Log("[ZombieAI] Player hit zombie with F");
                zh.TakeDamage(damageFromPlayer);
            }
        }
    }
}
