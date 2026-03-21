using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    void Start()
    {
        float health = 1004f;
        float poisonDamage = 125.5f;
        while (health > 0)
        {
            Debug.Log(health);
            health -= poisonDamage;
        }
        if (health <= 0)
        {
            Debug.Log(0);
            Debug.Log("Player has been Killed");
        }
    }
}
