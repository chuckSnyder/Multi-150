using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        string ballTag = other.gameObject.tag;
        
        if (ballTag.Contains(gameObject.tag))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            
            if (gm != null)
            {
                gm.playerScore++;
            }

            Debug.Log(gameObject.name + " scored with " + ballTag);
            Destroy(other.gameObject); 
        }
        else 
        {
            Debug.Log("Wrong ball! Goal is " + gameObject.tag + " but ball is " + ballTag);
        }
    }
}