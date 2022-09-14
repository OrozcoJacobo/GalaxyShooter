using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public TextMeshProUGUI waveName;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn= true;
    private bool canAnimate = false;

    private float nextSpawnTime;
    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0)
        {
            if (currentWaveNumber + 1 != waves.Length)
            {
                if(canAnimate == true)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
            }
            else
            {
                Debug.Log("Game Finished");
            }
        }

    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies;
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if(waves[currentWaveNumber].waveName == "Final Wave")
            {
                
                Instantiate(randomEnemy, spawnBoss.position, Quaternion.Euler(0, 0, -90));
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
                canAnimate = true;
            }
        }

    }
}
