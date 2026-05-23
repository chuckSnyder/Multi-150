using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct ObstacleRarity
    {
        public string label;            
        public GameObject prefab;      
        [Range(1, 100)] 
        public int spawnWeight;         
    }

    [Header("Spawn Inventory & Rarity Config")]
    public List<ObstacleRarity> hazardPool = new List<ObstacleRarity>();

    [Header("Spawning Controls")]
    public float baseSpawnInterval = 2.0f; 
    public float xSpawnRange = 4.0f;   

    private float timer = 0f;

    void Update()
    {
        float currentSpeed = GameManager.Instance != null ? GameManager.Instance.CurrentSpeed : 12f;
        float dynamicInterval = baseSpawnInterval * (12f / currentSpeed);
        dynamicInterval = Mathf.Max(dynamicInterval, 0.4f);

        timer += Time.unscaledDeltaTime;

        if (timer >= dynamicInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (hazardPool.Count == 0)
        {
            Debug.LogWarning("SPAWNER WARNING: Your Hazard Pool list is empty!");
            return;
        }
        int totalWeight = 0;
        foreach (var hazard in hazardPool)
        {
            if (hazard.prefab != null)
            {
                totalWeight += hazard.spawnWeight;
            }
        }

        if (totalWeight <= 0) return;
        int randomRoll = Random.Range(0, totalWeight);
        GameObject selectedPrefab = null;
        int weightCounter = 0;
        foreach (var hazard in hazardPool)
        {
            if (hazard.prefab == null) continue;

            weightCounter += hazard.spawnWeight;
            if (randomRoll < weightCounter)
            {
                selectedPrefab = hazard.prefab;
                break;
            }
        }
        if (selectedPrefab != null)
        {
            if (selectedPrefab.name.Contains("Totem") || selectedPrefab.GetComponent<TotemPowerUp>() != null)
            {
                if (TotemPowerUp.ActiveTotemCount > 0)
                {
                    return; // Abort spawning this turn because a totem is already active
                }
            }

            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
            Instantiate(selectedPrefab, spawnPosition, selectedPrefab.transform.rotation);
        }
    }
}