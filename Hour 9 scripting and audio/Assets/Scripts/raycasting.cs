using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasting : MonoBehaviour
{
    void Update()
    {
        float dirX = Input.GetAxis("Mouse X");
        float dirY = Input.GetAxis("Mouse Y");

        transform.Rotate(dirY, -dirX, 0);
        Checkforraycast();
    }
    void Checkforraycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.Log("The ray hit: " + hit.collider.gameObject.name);
        }
    }
}