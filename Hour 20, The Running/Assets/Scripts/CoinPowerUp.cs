using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerUp : MonoBehaviour
{
    [Header("Movement")]
    public float rotationSpeed = 250f;

    [Header("Blast Settings")]
    public float blastRadius = 15f; 

    void Start()
    {
        if (GetComponent<Renderer>() != null) 
            GetComponent<Renderer>().material.color = new Color(0f, 0f, 4f); 
    }

    void Update()
    {
        if (!transform.parent) 
        {
            float currentSpeed = GameManager.Instance != null ? GameManager.Instance.CurrentSpeed : 12f;
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.CompareTag("Player"))
        {
            TriggerMathBlast(other.transform.position);
            Destroy(gameObject);
        }
        if (other.gameObject.name == "killbox") 
        {
            Destroy(gameObject);
        }
    }

    void TriggerMathBlast(Vector3 playerPosition)
    {
        Debug.Log("COIN COLLECTED! purging nearby enemy...");

        MonoBehaviour[] allObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        foreach (MonoBehaviour obj in allObjects)
        {
            if (obj == null || obj.gameObject == null) continue;

            if (obj.gameObject.name.Contains("Cube") || 
                obj.gameObject.name.Contains("Enemy") || 
                obj.gameObject.name.Contains("DISPA") ||
                obj.GetType().Name == "ObstacleMovement" ||
                obj.GetType().Name == "EvilCube" ||
                obj.GetType().Name == "StalkerCube" ||
                obj.GetType().Name == "ZigZagCube" ||
                obj.GetType().Name == "PhasingCube" ||
                obj.GetType().Name == "WallDespairCube")
            {
                // Make sure it doesn't target the player or this coin asset
                if (obj.gameObject != this.gameObject && !obj.gameObject.CompareTag("Player") && obj.gameObject.name != "Player")
                {
                    float distance = Vector3.Distance(playerPosition, obj.transform.position);
                    if (distance <= blastRadius)
                    {
                        Destroy(obj.gameObject);
                    }
                }
            }
        }
    }
}
