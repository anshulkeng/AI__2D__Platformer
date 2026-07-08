using UnityEngine;

public class BatCompanionAI : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform player;
    public float offsetX = 1.5f;
    public float offsetY = 2f;
    public float followSpeed = 5f;

    [Header("Combat Assist (after late waves)")]
    public bool combatAssistEnabled = false;
    public float assistRange = 6f;
    public float assistCooldown = 2f;

    [Header("Danger Warning")]
    public bool warningEnabled = true;
    public float warningRange = 10f;      // how far to start warning
    public Color warningColor = Color.red;

    private float lastAssistTime = 0f;
    private SpriteRenderer sr;
    private Color normalColor;

    void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            normalColor = sr.color;
        }
    }

    void Update()
    {
        if (player == null) return;

        FollowPlayer();

        if (warningEnabled)
        {
            CheckDangerAndWarn();
        }

        if (combatAssistEnabled)
        {
            AssistCombat();
        }
    }

    void FollowPlayer()
    {
        Vector3 targetPos = player.position + new Vector3(offsetX, offsetY, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    // 1) DANGER WARNING
    void CheckDangerAndWarn()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closest = Mathf.Infinity;

        foreach (GameObject e in enemies)
        {
            float d = Vector2.Distance(transform.position, e.transform.position);
            if (d < closest)
                closest = d;
        }

        if (enemies.Length > 0 && closest <= warningRange)
        {
            // enemy close → bat turns red
            if (sr != null) sr.color = warningColor;
        }
        else
        {
            // safe → back to normal color
            if (sr != null) sr.color = normalColor;
        }
    }

    // 2) COMBAT ASSIST (same as before, plus little jump to zombie)
    void AssistCombat()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float bestDist = Mathf.Infinity;

        foreach (GameObject e in enemies)
        {
            float d = Vector2.Distance(transform.position, e.transform.position);
            if (d < assistRange && d < bestDist)
            {
                bestDist = d;
                nearest = e;
            }
        }

        if (nearest == null) return;
        if (Time.time < lastAssistTime + assistCooldown) return;

        ZombieHealth zh = nearest.GetComponent<ZombieHealth>();
        if (zh != null)
        {
            // move bat near zombie for "bite" effect
            Vector3 bitePos = nearest.transform.position + new Vector3(0.5f, 1f, 0f);
            transform.position = bitePos;

            int damage = Mathf.Max(1, Mathf.RoundToInt(zh.maxHealth * 0.05f)); // 5% HP
            zh.TakeDamage(damage);
            lastAssistTime = Time.time;

            Debug.Log("[Bat] Assisted hit " + damage + " dmg on " + nearest.name);
        }
    }
}
