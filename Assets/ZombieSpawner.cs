using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [Header("What to spawn")]
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;

    [Header("How many zombies in this zone")]
    public int minZombies = 1;
    public int maxZombies = 2;

    [Header("Zombie stats for this wave")]
    public int attackDamageForWave = 10;   // damage TO player
    public int healthForWave = 80;         // HP for each zombie

    [Header("Bat behaviour for this wave")]
    public bool enableBatCombatOnThisWave = false; 

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        if (zombiePrefab == null)
        {
            Debug.LogWarning("[ZombieSpawner] No zombiePrefab assigned on " + gameObject.name);
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("[ZombieSpawner] No spawnPoints assigned on " + gameObject.name);
            return;
        }

        int count = Random.Range(minZombies, maxZombies + 1);
        Debug.Log("[ZombieSpawner] Spawning " + count + " zombies on " + gameObject.name +
                  " | atk = " + attackDamageForWave + " | HP = " + healthForWave);

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Transform sp = spawnPoints[index];

            GameObject z = Instantiate(zombiePrefab, sp.position, Quaternion.identity);

            // set attack damage
            ZombieAI ai = z.GetComponent<ZombieAI>();
            if (ai != null)
            {
                ai.attackDamage = attackDamageForWave;
            }

            // set health
            ZombieHealth zh = z.GetComponent<ZombieHealth>();
            if (zh != null)
            {
                zh.SetMaxHealth(healthForWave);
            }
        }

        if (enableBatCombatOnThisWave)
        {
            BatCompanionAI bat = FindObjectOfType<BatCompanionAI>();
            if (bat != null)
            {
                bat.combatAssistEnabled = true;
                Debug.Log("[ZombieSpawner] Bat combat assist ENABLED from " + gameObject.name);
            }
        }
    }
}
