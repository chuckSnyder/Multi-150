using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryDoughnut : MonoBehaviour
{
    [Header("Powerup Settings")]
    public float slowAmount = 4f; // How much speed is stripped from Ollie the cat

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the doughnut is the Player
        if (other.CompareTag("Player"))
        {
            // Locate Ollie in the scene using your new script name
            EvilCatChase ollieCat = FindObjectOfType<EvilCatChase>();
            
            if (ollieCat != null)
            {
                // Slow Ollie down!
                ollieCat.SlowDownCat(slowAmount);
                Debug.Log("Doughnut collected! Ollie has been slowed down by " + slowAmount);
            }
            else
            {
                Debug.LogWarning("Doughnut collected, but couldn't find Ollie (EvilCatChase script) in the scene!");
            }

            // Destroys the doughnut pickup instance
            Destroy(gameObject);
        }
    }
}
