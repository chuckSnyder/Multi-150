using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Speed Progression")]
    public float initialGameSpeed = 12f;
    public float maxGameSpeed = 30f;
    public float speedIncreaseRate = 0.2f;

    [Header("UI Display")]
    public TextMeshProUGUI scoreTextDisplay; // Drag your ScoreText object here!

    public float CurrentSpeed { get; private set; }
    public float CurrentScore { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
        CurrentSpeed = initialGameSpeed;
        CurrentScore = 0f;
        UpdateScoreUI();
    }

    void Update()
    {
        if (CurrentSpeed < maxGameSpeed)
        {
            CurrentSpeed += speedIncreaseRate * Time.deltaTime;
        }

        CurrentScore += Time.deltaTime * 1f;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreTextDisplay != null)
        {
            scoreTextDisplay.text = Mathf.FloorToInt(CurrentScore).ToString();
        }
    }
}