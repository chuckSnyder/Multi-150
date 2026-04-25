using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volocity : MonoBehaviour
{
    public float startSpeed = 50f; 

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            rb.velocity = randomDirection.normalized * startSpeed;
        }
        else
        {
            Debug.LogError("Hey! You forgot to add a Rigidbody to: " + gameObject.name);
        }
    }
}