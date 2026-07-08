using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public bool requireAllZombiesDead = true;
    private bool levelFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelFinished) return;
        if (!other.CompareTag("Player")) return;

        if (requireAllZombiesDead)
        {
            // check if any enemies are still alive
            GameObject[] remaining = GameObject.FindGameObjectsWithTag("Enemy");
            if (remaining.Length > 0)
            {
                Debug.Log("[LevelEnd] Reach flag, but zombies still alive!");
                return;
            }
        }

        levelFinished = true;
        Debug.Log("[LevelEnd] LEVEL COMPLETE! 🎉");

        // stop the game
        Time.timeScale = 0f;
    }
}
