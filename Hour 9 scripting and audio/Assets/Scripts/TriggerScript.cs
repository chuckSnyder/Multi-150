using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " has entered the cube");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + " is still in the cube");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " has left the cube");
    }
}
