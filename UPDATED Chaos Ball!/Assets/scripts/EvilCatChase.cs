using UnityEngine;

public class EvilCatChase : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform playerTransform; 
    public float baseSpeed = 3f;
    public float accelerationRate = 0.2f; 
    
    private float currentSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = baseSpeed;

        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            currentSpeed += accelerationRate * Time.fixedDeltaTime;

            Vector3 direction = (playerTransform.position - transform.position).normalized;
            direction.y = 0; 

            rb.MovePosition(transform.position + direction * currentSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager manager = FindObjectOfType<GameManager>();
            if (manager != null)
            {
                manager.TriggerCatGameOver();
            }
        }
    }

    public void SlowDownCat(float slowAmount)
    {
        currentSpeed -= slowAmount;
        if (currentSpeed < baseSpeed) 
        {
            currentSpeed = baseSpeed;
        }
    }
}