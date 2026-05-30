using UnityEngine;

public class BallIdentity : MonoBehaviour
{
    public string lastTouchedBy = "PLAYER"; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lastTouchedBy = "PLAYER";
            Debug.Log("The Player touched me! My hero.");
        }
    }
}