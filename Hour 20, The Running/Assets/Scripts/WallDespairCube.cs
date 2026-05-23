using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDespairCube : MonoBehaviour
{
    [Header("Growth Settings")]
    public float growthSpeed = 0.3f;    
    public float maxScaleX = 7f;         
    public float triggerDistance = 30f; 

    private Transform playerTransform;
    private bool isTriggered = false;

    void Start()
    {
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(2f, 2f, 2f); 

        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        float dynamicForwardSpeed = GameManager.Instance.CurrentSpeed;

        transform.Translate(Vector3.back * dynamicForwardSpeed * Time.deltaTime, Space.World);

        if (playerTransform != null && !isTriggered)
        {
            float distanceToPlayer = transform.position.z - playerTransform.position.z;
            
            if (distanceToPlayer <= triggerDistance)
            {
                isTriggered = true;
            }
        }

        if (isTriggered && transform.localScale.x < maxScaleX)
        {
            float dynamicGrowth = growthSpeed * dynamicForwardSpeed * Time.deltaTime;
            
            float newScaleX = transform.localScale.x + dynamicGrowth;
            newScaleX = Mathf.Min(newScaleX, maxScaleX); 
            
            transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
        }

        if (transform.position.z < -10f) 
        {
            Destroy(gameObject);
        }
    }
}