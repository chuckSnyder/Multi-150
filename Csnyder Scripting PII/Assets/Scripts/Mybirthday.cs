using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mybirthday : MonoBehaviour
{
    void Start()
    {
        int birthday = 30;
        int daysInMonth = 31;

        for (int i = 1; i <= daysInMonth; i++)
        {
            if (i == birthday)
            {
                Debug.Log("Its my birthday!");
            }
            else
            {
                Debug.Log(i);
            }
        }
    }
}