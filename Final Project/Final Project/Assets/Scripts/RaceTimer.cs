using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceTimer : MonoBehaviour
{
    public float raceDuration = 12f; // 2 minutes
    public TextMeshProUGUI timerText; // Timer UI text
    public TextMeshProUGUI lapText; // Lap counter UI text
    public TextMeshProUGUI messageText; // Message UI text for penalties or win message

    private float remainingTime;
    private int completedLaps = 0;
    private bool raceActive = true;

    void Start()
    {
        remainingTime = raceDuration;
        UpdateTimerUI();
        UpdateLapUI();
        messageText.text = "Start The game"; // Clear the message at the start
        Invoke("ClearMessage", 2f);
    }

    void Update()
    {
        if (raceActive)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                EndRace();
            }

            UpdateTimerUI();
        }
    }

    public void CompleteLap()
    {
        if (raceActive)
        {
            completedLaps++;
            UpdateLapUI();
            messageText.text = "Lap Completed!";
            Invoke("ClearMessage", 2f); // Clear message after 2 seconds
        }
    }

    public void CrashObstacle()
    {
        if (raceActive)
        {
            remainingTime -= 10f; // Penalty of 10 seconds
            messageText.text = "10 Seconds Penalty!";
            Invoke("ClearMessage", 2f); // Clear message after 2 seconds
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.Max(0, remainingTime).ToString("F2") + "s";
    }

    void UpdateLapUI()
    {
        lapText.text = "Laps: " + completedLaps;
    }

    void ClearMessage()
    {
        messageText.text = "";
    }

    void EndRace()
    {
        raceActive = false;
        messageText.text = "Race Over! Total Laps: " + completedLaps;
    }
}
