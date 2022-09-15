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

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn= true;
    private bool canAnimate = false;

    private int nextItem;
    private int nextSpawner;

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



            //about to implement logic in order to spawn powerups, 
            //power ups and spawn points are both in lists
            //select random number from each and use it 
            StartCoroutine(SpawnPowerUp());

            if (waves[currentWaveNumber].waveName == "Final Wave")
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
    IEnumerator SpawnPowerUp()
    {
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

        if (waves[currentWaveNumber].waveName == "Final Wave" && canSpawn)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(powerUpsPrefabs[nextItem], powerUpSpawners[nextSpawner].transform.position, Quaternion.identity);  
        }
        else if(canSpawn)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(powerUpsPrefabs[nextItem], powerUpSpawners[nextSpawner].transform.position, Quaternion.identity);
        }
        


        /*
        timePassed += Time.deltaTime;

        if (waves[currentWaveNumber].waveName == "Final Wave")
        {
            if(spawnInterval < timePassed)
            {
                spawnInterval += 5;
                Instantiate(powerUpsPrefabs[nextItem], powerUpSpawners[nextSpawner].transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (spawnInterval < timePassed)
            {
                spawnInterval += 3;
                Instantiate(powerUpsPrefabs[nextItem], powerUpSpawners[nextSpawner].transform.position, Quaternion.identity);
            }
        }
        */

    }
}
