using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGameManager : MonoBehaviour
{
    // VARIABLES belong out here at the top of the class, not inside Start()!
    public TextureScroller ground;
    public float gameTime = 10f;
    float totalTimeElapsed = 0f;
    bool isGameOver = false; // Added missing semicolon

    void Start()
    {
        // Start can remain empty for now if the book doesn't use it yet
    }
   
    void Update()
    {
        if (isGameOver)
            return;

        totalTimeElapsed += Time.deltaTime; // Added missing semicolon
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
            isGameOver = true; // Fixed capitalization of 'isGameOver'
    }

    // Fixed 'Void' -> 'void' and 'Adjusttime' -> 'AdjustTime'
    public void AdjustTime(float amount)
    { 
        gameTime += amount; // Fixed capitalization of 'gameTime'
        
        // C# requires parentheses () around 'if' conditions
        if (amount < 0) 
            SlowWorldDown();
    }

    // Methods require parentheses () after their name
    void SlowWorldDown()
    {
        CancelInvoke();
        Time.timeScale = 0.5f; // Fixed 'timescale' -> 'timeScale'
        Invoke("speedWorldUp", 1f); // Fixed method string name to match below
    }

    // Fixed 'Void' -> 'void' and 'speedWorldup' -> 'speedWorldUp'
    void speedWorldUp()
    {
        Time.timeScale = 1f; // Fixed 'timescale' -> 'timeScale'
    }

    // Fixed 'On GUI' -> 'OnGUI()'
    void OnGUI()
    {
        if (!isGameOver) // Fixed capitalization of 'isGameOver'
        {
            // Fixed 'rect'->'Rect', 'newRect'->'new Rect', 'Screenwidth'->'Screen.width', 'Screen.heighth'->'Screen.height'
            Rect boxRect = new Rect(Screen.width / 2 - 50, Screen.height - 100, 100, 50);
            GUI.Box(boxRect, "Time Remaining"); // Fixed 'GUI.box' -> 'GUI.Box'

            // Fixed 'Rect LabelRect newRect' syntax errors
            Rect labelRect = new Rect(Screen.width / 2 - 10, Screen.height - 80, 20, 40);
            GUI.Label(labelRect, ((int)gameTime).ToString()); // Fixed '(Int)' -> '(int)'
        }
        else
        {
            // Fixed missing closing parenthesis and spelling of 'Screen.height'
            Rect boxRect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50);
            GUI.Box(boxRect, "Game Over");
            
            // Fixed quotes and string closing format
            Rect labelRect = new Rect(Screen.width / 2 - 55, Screen.height / 2 - 80, 90, 40);
            GUI.Label(labelRect, "Total Time: " + (int)totalTimeElapsed);
            
            Time.timeScale = 0f; // Fixed 'time.timescale' -> 'Time.timeScale'
        }
    }
}