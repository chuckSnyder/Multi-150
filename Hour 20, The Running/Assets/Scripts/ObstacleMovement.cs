using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    void Update()
    {
        float dynamicSpeed = GameManager.Instance.CurrentSpeed;

        transform.Translate(Vector3.back * dynamicSpeed * Time.deltaTime, Space.World);

        if (transform.position.z < -10f) Destroy(gameObject);
    }
}