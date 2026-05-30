using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float timer = 60f;
    public int playerScore = 0;
    
    [Header("State")]
    public bool isGameOver = false;
    private bool caughtByCat = false; 

    void Update()
    {
        if (isGameOver) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            EndGame();
        }
    }

    public void TriggerCatGameOver()
    {
        if (isGameOver) return; 
        caughtByCat = true;
        EndGame();
    }

    void EndGame()
    {
        isGameOver = true;
        timer = 0;
        Time.timeScale = 0; // Freeze all physics and movement
        
        GameObject cat = GameObject.Find("OiiaCat"); 

        if (cat != null)
        {
            AudioSource source = cat.GetComponent<AudioSource>();
            if (source != null)
            {
                source.loop = true;
                source.pitch = 1.2f;
                if (!source.isPlaying) source.Play();
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 60), "SURVIVAL");
        GUI.Label(new Rect(20, 30, 130, 20), "TIME: " + Mathf.Round(timer));
        GUI.Label(new Rect(20, 50, 130, 20), "SCORE: " + playerScore);
        
        if (isGameOver)
        {
            GUI.backgroundColor = Color.black;
            
            Rect windowRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 160);
            string resultTitle = "";
            
            if (caughtByCat) {
                resultTitle = "CAUGHT BY OIIA OIIA CAT!";
            } else {
                resultTitle = "YOU SURVIVED THE CAT!";
            }

            GUI.Window(0, windowRect, DrawGameOverWindow, resultTitle);
        }
    }

    void DrawGameOverWindow(int windowID)
    {
        GUI.Label(new Rect(50, 40, 200, 20), "Final Score: " + playerScore);

        GUI.backgroundColor = Color.red;
        if (GUI.Button(new Rect(100, 90, 100, 40), "RETRY?"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}