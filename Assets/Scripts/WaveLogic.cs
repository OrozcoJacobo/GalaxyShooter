using UnityEngine;
[System.Serializable]
public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject typeOfEnemies;
    public float spawnInterval;
}

public class WaveLogic : MonoBehaviour
{
    [SerializeField]
    Wave[] waves;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private Transform spawnBoss;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn= true;

    private float nextSpawnTime;
    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && !canSpawn)
        {
            currentWaveNumber++;
            canSpawn = true;

        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies;
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if(currentWaveNumber == 2)
            {
                
                Instantiate(randomEnemy, spawnBoss.position, Quaternion.identity);
            }
            else
            {
                Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            }
            
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
            }
        }

    }
}
