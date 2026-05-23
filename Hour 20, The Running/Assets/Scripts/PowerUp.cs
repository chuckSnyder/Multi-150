using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float forwardSpeed = 12f;
    public float rotationSpeed = 100f;
    public float shieldDuration = 5f;

    void Start()
    {
        if (GameManager.Instance != null) forwardSpeed = GameManager.Instance.CurrentSpeed;
        
        if (GetComponent<Renderer>() != null) GetComponent<Renderer>().material.color = Color.cyan;
    }

    void Update()
    {
        if (GameManager.Instance != null) forwardSpeed = GameManager.Instance.CurrentSpeed;
        transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime, Space.World);

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.gameObject.name == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateShield(shieldDuration);
            }

            Destroy(gameObject); 
        }

        if (other.gameObject.name == "killbox") Destroy(gameObject);
    }
}
