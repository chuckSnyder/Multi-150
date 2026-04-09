using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int healthpoints = 3992;

    void Start()
    {
        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);

        healthpoints = UsePotion(healthpoints);
        Debug.Log("Health: " + healthpoints);
    }

    void Update()
    {

    }

    int UsePotion(int health)
    {
        health += 400;
        return health;
    }
}