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
            BallIdentity ballInfo = other.gameObject.GetComponent<BallIdentity>();
            if (gm != null && ballInfo != null)
            {
                if (ballInfo.lastTouchedBy == "AI")
                {
                    gm.aiScore++;
                }
                else
                {
                    gm.playerScore++;
                }
            }

            Debug.Log(gameObject.name + " scored with " + ballTag);
            Destroy(other.gameObject); 
        }
        else 
        {
            // Optional: Log if the wrong ball enters the goal
            Debug.Log("Wrong ball! Goal is " + gameObject.tag + " but ball is " + ballTag);
        }
    }
}