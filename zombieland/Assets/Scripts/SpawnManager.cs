using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float[] values = { 1.5f, 0f, -1.5f };
    private float startDelay = 1.0f;  
    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomEnemy", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            // Check if the current enemy's position is greater than 5 on the Z-axis
            if (enemyPrefabs[i].transform.position.z > 5)
            {
                // Destroy the individual enemy
                Destroy(enemyPrefabs[i]);
            }
        }
        
    }
    
    

void SpawnRandomEnemy()
{
    
       if (canSpawn)
    {
        float spawnInterval = Random.Range(1.5f, 3.0f);

        // Randomly select two different positions on the road
        int randomIndex1 = Random.Range(0, values.Length);
        int randomIndex2;

        do
        {
            randomIndex2 = Random.Range(0, values.Length);
        } while (randomIndex2 == randomIndex1);

        float selectedValue1 = values[randomIndex1];
        float selectedValue2 = values[randomIndex2];

        // Spawn enemies at the selected positions
        int index1 = Random.Range(0, enemyPrefabs.Length);
        int index2 = Random.Range(0, enemyPrefabs.Length);

        Vector3 spawnPos1 = new Vector3(selectedValue1, 0, -20);
        Vector3 spawnPos2 = new Vector3(selectedValue2, 0, -20);

        Instantiate(enemyPrefabs[index1], spawnPos1, enemyPrefabs[index1].transform.rotation);
        Instantiate(enemyPrefabs[index2], spawnPos2, enemyPrefabs[index2].transform.rotation);

        Invoke("SpawnRandomEnemy", spawnInterval);
    }
        else
        {
            StopSpawn();
            // Spawn işlemini durdurmak için bir şey yapabilirsiniz, veya bu bloğu boş bırakabilirsiniz.
            // Örneğin: Debug.Log("Spawn işlemi durduruldu");
        }
        
    }

    public void StopSpawn()
    {
         Enemy[] activeEnemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in activeEnemies)
        {
            enemy.speed_e = 0f;
        }
        canSpawn = false;
    }
}



