using UnityEngine;

public class ZigZagCube : MonoBehaviour
{
    [Header("Horizontal Bouncing Speed")]
    public float sideSpeed = 8f;
    public float xRange = 4.5f;

    private int direction = 1;

    void Update()
    {
        float dynamicForwardSpeed = GameManager.Instance.CurrentSpeed;
        transform.Translate(Vector3.back * dynamicForwardSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * direction * sideSpeed * Time.deltaTime, Space.World);

        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            direction = -1;
        }
        else if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            direction = 1;
        }

        if (transform.position.z < -10f) Destroy(gameObject);
    }
}