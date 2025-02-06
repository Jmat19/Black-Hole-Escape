using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Assign these in the Unity Editor
    public GameObject objectToSpawn;  // Prefab for the objects to spawn
    public Transform[] spawnPoints;  // Three spawn positions assigned in the editor
    public float spawnInterval = 2f;  // Interval between spawns

    private void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned.");
            return;
        }

        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = spawnedObject.AddComponent<Rigidbody>();
        }

        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player interacted with a falling object!");
            Destroy(other.gameObject); // Customize as per the game logic
        }
    }
}
