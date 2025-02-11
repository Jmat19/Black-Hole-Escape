using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Game Objects to Spawn")]
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    [Header("Spawn Points")]
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;

    [Header("Spawn Time Interval (in seconds)")]
    public float spawnInterval = 2f;
    public float doubleSpawnChance = 0.8f; // 60% chance to spawn two objects

    private GameObject[] objects;
    private Transform[] spawnPoints;
    private List<Transform> availableSpawnPoints;

    private void Start()
    {
        objects = new GameObject[] { object1, object2, object3 };
        spawnPoints = new Transform[] { spawnPoint1, spawnPoint2, spawnPoint3 };

        StartCoroutine(SpawnObjectsRandomly());
    }

    private IEnumerator SpawnObjectsRandomly()
    {
        while (true)
        {
            availableSpawnPoints = new List<Transform>(spawnPoints);
            SpawnSingleObject();

            if (Random.value < doubleSpawnChance && availableSpawnPoints.Count > 0)
            {
                SpawnSingleObject();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnSingleObject()
    {
        if (availableSpawnPoints.Count == 0) return;

        GameObject selectedObject = objects[Random.Range(0, objects.Length)];
        int spawnIndex = Random.Range(0, availableSpawnPoints.Count);
        Transform selectedSpawnPoint = availableSpawnPoints[spawnIndex];
        availableSpawnPoints.RemoveAt(spawnIndex);

        if (selectedObject != null && selectedSpawnPoint != null)
        {
            Instantiate(selectedObject, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }
    }
}
