using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;      // what to spawn
    public Transform[] spawnPoints;    // where to spawn
    public float spawnInterval = 3f;   // time between spawns (seconds)

    private float timer = 0f;

    void Update()
    {
        // count up with time
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f; // reset timer
        }
    }

    void SpawnCoin()
    {
        if (coinPrefab == null || spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("CoinSpawner: missing prefab or spawn points!");
            return;
        }

        // choose a random spawn point
        int index = Random.Range(0, spawnPoints.Length);
        Transform point = spawnPoints[index];

        // create a new coin at that position
        Instantiate(coinPrefab, point.position, Quaternion.identity);
    }
}
