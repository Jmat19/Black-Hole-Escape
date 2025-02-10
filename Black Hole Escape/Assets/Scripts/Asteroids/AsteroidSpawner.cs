using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject spawnedAsteroid;

    public float timeToSpawn, spawnCountdown;

    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;

        if (spawnCountdown <= 0 ) 
        {
            spawnCountdown = timeToSpawn;

            Instantiate(spawnedAsteroid, transform.position, transform.rotation);
        }
    }
}
