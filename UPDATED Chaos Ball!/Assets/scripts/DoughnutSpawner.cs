using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject doughnutPrefab;
    public int totalDoughnuts = 5;

    [Header("Arena Spawn Boundaries")]
    // Adjust these values to match the exact size of your floor plane!
    public float minX = -15f;
    public float maxX = 15f;
    public float minZ = -15f;
    public float maxZ = 15f;
    public float spawnHeightY = 0.5f; // Keeps it floating slightly off the floor

    void Start()
    {
        SpawnDoughnutsRandomly();
    }

    void SpawnDoughnutsRandomly()
    {
        if (doughnutPrefab == null)
        {
            Debug.LogError("DoughnutSpawner: Please assign the Doughnut Prefab in the Inspector!");
            return;
        }

        for (int i = 0; i < totalDoughnuts; i++)
        {
            // 1. Generate a random coordinate strictly within the playable arena bounds
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            
            Vector3 spawnPosition = new Vector3(randomX, spawnHeightY, randomZ);

            // 2. Instantiate the doughnut at that exact safe vector
            Instantiate(doughnutPrefab, spawnPosition, Quaternion.identity);
        }
    }
}