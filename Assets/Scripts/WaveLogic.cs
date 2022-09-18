using System.Collections;
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
    private TextMeshProUGUI waveName;
    [SerializeField]
    private GameObject[] powerUpSpawners;
    [SerializeField]
    private GameObject[] powerUpsPrefabs;
    [SerializeField]
    private GameObject[] asteroidSpawners;
    [SerializeField]
    private GameObject asteriodPrefab;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn= true;
    private bool canAnimate = false;

    private int nextItem;
    private int nextSpawner;

    private float nextSpawnTime;
    private float nextSpawnTimePower;

    private bool canSpawnAsteriods = true;
    private bool canSpawnPowerUps = true;
    private bool canSpawnExtras = true;
    

    private int nextAsteriodSpawner;

    private void Start()
    {
        Debug.Log("Hello" + canSpawnExtras);
        InvokeRepeating(nameof(PowerUps), 3f, 3f);
        InvokeRepeating(nameof(Asteroids), 3f, 3f);
    }
    private void Update()
    {

        currentWave = waves[currentWaveNumber];
        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0)
        {
            //canSpawnExtras = false;
            if (currentWaveNumber + 1 != waves.Length)
            {
                if(canAnimate == true)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                    canSpawnExtras = false;
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
        canSpawnExtras = true;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies;
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            //about to implement logic in order to spawn powerups, 
            //power ups and spawn points are both in lists
            //select random number from each and use it 
            
            //StartCoroutine(SpawnPowerUp());
            //StartCoroutine(SpawnAsteroids());

            if (waves[currentWaveNumber].waveName == "Final Wave")
            {
                
                Instantiate(randomEnemy, spawnBoss.position, Quaternion.Euler(0, 0, -90));
            }
            else
            {
                Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            }
            //canSpawnAsteriods = true;
            //canSpawnPowerUps = true;
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
                canAnimate = true;
            }
        }

    }

    /*
    private void SpawnPowerUps()
    {
        Debug.Log("Enter spawn powerup");
 
        StartCoroutine(PowerUps());
        
    }
   */

    //IEnumerator PowerUps()
    private void PowerUps()
    {
        Debug.Log("PowerUps Enter" + canSpawnExtras);
        if (waves[currentWaveNumber].waveName == "Final Wave" && canSpawnExtras)
        {
            Debug.Log("Enter boss wave power up spawn");
            nextItem++;
            if (nextItem > 2)
            {
                nextItem = 0;
            }

            nextSpawner++;
            if (nextSpawner > 1)
            {
                nextSpawner = 0;
            }
           
            Instantiate(powerUpsPrefabs[nextItem], powerUpSpawners[nextSpawner].transform.position, Quaternion.identity);
            //canSpawnPowerUps = false;
        }
        else if(canSpawnExtras)
        {
            Debug.Log("Enter normal wave power up spawn");
            nextItem++;
            if (nextItem > 2)
            {
                nextItem = 0;
            }

            nextSpawner++;
            if (nextSpawner > 1)
            {
                nextSpawner = 0;
            }
            
            Instantiate(powerUpsPrefabs[nextItem], powerUpSpawners[nextSpawner].transform.position, Quaternion.identity);
            //canSpawnPowerUps = false;
        }
    }

    /*private void SpawnAsteroids()
    {
 
        StartCoroutine(Asteroids());
        
    }
    */

    private void Asteroids()
    {
        nextAsteriodSpawner++;
        if(nextAsteriodSpawner > 1)
        {
            nextAsteriodSpawner = 0;
        }
        if(canSpawnExtras)
        {
            Instantiate(asteriodPrefab, asteroidSpawners[nextAsteriodSpawner].transform.position, Quaternion.identity);
        }
       
        
    }
   
}
