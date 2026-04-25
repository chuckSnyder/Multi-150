using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float timer = 60f;
    public int playerScore = 0;
    public int aiScore = 0;
    
    [Header("State")]
    public bool isGameOver = false;

    void Update()
    {
        // Don't do anything if the game is over
        if (isGameOver) return;

        // Countdown timer
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameOver = true;
        timer = 0;
        Time.timeScale = 0; // Freeze all physics and movement
        GameObject ai = GameObject.Find("EvilAI");
        if (ai != null)
        {
            AudioSource source = ai.GetComponent<AudioSource>();
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
        // --- HUD (Top Left) ---
        GUI.Box(new Rect(10, 10, 150, 80), "SCOREBOARD");
        GUI.Label(new Rect(20, 30, 130, 20), "TIME: " + Mathf.Round(timer));
        GUI.Label(new Rect(20, 50, 130, 20), "YOU: " + playerScore);
        GUI.Label(new Rect(20, 70, 130, 20), "THE BOX: " + aiScore);
        if (isGameOver)
        {
            // Dim the background (optional visual flair)
            GUI.backgroundColor = Color.black;
            
            Rect windowRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200);
            string resultTitle = "";
            if (aiScore > playerScore) {
                resultTitle = "DEFEATED BY A BOX";
            } else if (playerScore > aiScore) {
                resultTitle = "YOU OUT-SMARTED THE BOX!";
            } else {
                resultTitle = "TIE? THE BOX IS UNAMUSED.";
            }

            GUI.Window(0, windowRect, DrawGameOverWindow, resultTitle);
        }
    }

    void DrawGameOverWindow(int windowID)
    {
        GUI.Label(new Rect(50, 40, 200, 20), "Final Player Score: " + playerScore);
        GUI.Label(new Rect(50, 60, 200, 20), "Final AI Score: " + aiScore);

        GUI.backgroundColor = Color.red;
        if (GUI.Button(new Rect(100, 120, 100, 40), "RETRY?"))
        {
            Time.timeScale = 1; // RESET TIME SCALE BEFORE LOADING
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
