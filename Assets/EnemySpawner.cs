using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] private float timeClock;
    [SerializeField] private float timeSpanw;
    [SerializeField] Transform spawnPoint;
    // Update is called once per frame
    void Update()
    {
        timeClock -= Time.deltaTime;
        if (timeClock <= 0)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            timeClock = timeSpanw;
        }
    }
}
