using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Game Objects to Spawn")]
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject powerUp;

    [Header("Spawn Points")]
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;

    [Header("Spawn Time Interval (in seconds)")]
    public float spawnInterval = 2f;
    public float powerUpSpawnInterval = 5f;
    public float doubleSpawnChance = 0.8f; // 60% chance to spawn two objects

    private GameObject[] asteroids;
    private Transform[] spawnPoints;
    private List<Transform> availableSpawnPoints;

    private void Start()
    {
        asteroids = new GameObject[] { asteroid1, asteroid2, asteroid3 };
        spawnPoints = new Transform[] { spawnPoint1, spawnPoint2, spawnPoint3 };

        StartCoroutine(SpawnAsteroids());
        StartCoroutine(SpawnPowerUp());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            availableSpawnPoints = new List<Transform>(spawnPoints);
            SpawnSingleAsteroid();

            if (Random.value < doubleSpawnChance && availableSpawnPoints.Count > 0)
            {
                SpawnSingleAsteroid();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnSingleAsteroid()
    {
        if (availableSpawnPoints.Count == 0) return;

        GameObject selectedObject = asteroids[Random.Range(0, asteroids.Length)];
        int spawnIndex = Random.Range(0, availableSpawnPoints.Count);
        Transform selectedSpawnPoint = availableSpawnPoints[spawnIndex];
        availableSpawnPoints.RemoveAt(spawnIndex);

        if (selectedObject != null && selectedSpawnPoint != null)
        {
            Instantiate(selectedObject, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }
    }

    private IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnInterval);

            Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if (powerUp != null && selectedSpawnPoint != null)
            {
                Instantiate(powerUp, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
            }
        }
    }
}
