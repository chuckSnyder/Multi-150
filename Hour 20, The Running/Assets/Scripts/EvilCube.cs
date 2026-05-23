using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCube : MonoBehaviour
{
    [Header("Darting Settings")]
    public float dartSpeed = 15f;    
    public float triggerDistance = 20f;

    private Transform playerTransform;
    private bool hasDarted = false;
    private float targetX;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null) playerTransform = player.transform;
    }

    void Update()
    {
        float dynamicForwardSpeed = GameManager.Instance.CurrentSpeed;

        transform.Translate(Vector3.back * dynamicForwardSpeed * Time.deltaTime, Space.World);
        if (playerTransform != null && !hasDarted)
        {
            if (transform.position.z - playerTransform.position.z <= triggerDistance)
            {
                targetX = playerTransform.position.x;
                hasDarted = true;
            }
        }

        if (hasDarted)
        {
            float newX = Mathf.MoveTowards(transform.position.x, targetX, dartSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -10f) Destroy(gameObject);
    }
}
