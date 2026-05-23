using UnityEngine;

public class StalkerCube : MonoBehaviour
{
    [Header("Horizontal Chasing Speed")]
    public float trackSpeed = 5f; 

    private Transform playerTransform;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null) playerTransform = player.transform;
    }

    void Update()
    {
        float dynamicForwardSpeed = GameManager.Instance.CurrentSpeed;

        transform.Translate(Vector3.back * dynamicForwardSpeed * Time.deltaTime, Space.World);

        if (playerTransform != null)
        {
            float targetX = playerTransform.position.x;
            float newX = Mathf.MoveTowards(transform.position.x, targetX, trackSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -10f) Destroy(gameObject);
    }
}