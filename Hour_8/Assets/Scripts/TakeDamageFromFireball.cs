using UnityEngine;

public class TakeDamageFromFireball : MonoBehaviour
{
    void Start()
    {

        int x = TakeDamage(); 
        Debug.Log("Player is HIT ()! New health: " + x);

        int y = TakeDamage(25);
        Debug.Log("Player is HIT (25 dmg)! New health: " + y);

        int z = TakeDamage(30, 50);
        Debug.Log("Player is HIT (30-50): " + z);
    }

    int TakeDamage()
    {
        int playerHealth = 100;
        return playerHealth - 5;
    }

    int TakeDamage(int damage)
    {
        int playerHealth = 100;
        return playerHealth - damage;
    }

    int TakeDamage(int damage, int playerHealth)
    {
        return playerHealth - damage;
    }
}
