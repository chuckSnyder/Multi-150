using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evens : MonoBehaviour
{
    void Start()
    {
        for (int i = 22; i <= 100; i += 2)
        {
            Debug.Log(i);
        }
    }
}