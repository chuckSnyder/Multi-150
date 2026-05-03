using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    public GameObject lampPrefab;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPosition = new Vector3(i * 5.0f, 0, 0);
            Instantiate(lampPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
