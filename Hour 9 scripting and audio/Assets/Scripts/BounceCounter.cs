using UnityEngine;

public class BounceCounter : MonoBehaviour
{
    private int count = 0; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Sphere"))
        {
            count++;
            Debug.Log("Total Bounces: " + count);
        }
    }
}
