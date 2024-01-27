using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatStreet : MonoBehaviour
{
    public GameObject streetPrefab;
    

    private float startDelay = 0;
    public bool canSpawn = true;


    void Start()
    {
        Invoke("SpawnStreet", startDelay);
    }

    void Update()
    {

    }

    void SpawnStreet()
    {
        
            float spawnDelay = 23.8f;
            Vector3 spawnPos = new Vector3(streetPrefab.transform.position.x, streetPrefab.transform.position.y, streetPrefab.transform.position.z - 72);

            Instantiate(streetPrefab, spawnPos, streetPrefab.transform.rotation);
            Invoke("SpawnStreet", spawnDelay);

                    
        
    }

    public void StopSpawnMap()
    {
        canSpawn = false;  // Set the flag to stop spawning
    }
}
