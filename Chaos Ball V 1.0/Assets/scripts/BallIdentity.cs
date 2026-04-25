using UnityEngine;

public class BallIdentity : MonoBehaviour
{
    public string lastTouchedBy = "PLAYER"; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            lastTouchedBy = "AI";
            Debug.Log("The Evil Cube touched me! Disgusting.");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            lastTouchedBy = "PLAYER";
            Debug.Log("The Player touched me! My hero.");
        }
    }
}
