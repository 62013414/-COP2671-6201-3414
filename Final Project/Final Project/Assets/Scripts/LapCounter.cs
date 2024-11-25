using UnityEngine;
using TMPro;  // TextMeshPro for UI text

public class LapTimer : MonoBehaviour
{
    public int totalLaps = 2;
    private int currentLap = 0;
    private bool raceStarted = false;

    public Transform startLine;
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI timerText;

    private float lapStartTime;
    private float raceTime;

    void Start()
    {
        UpdateLapText();
    }

    void Update()
    {
        if (raceStarted)
        {
            // Update the timer every frame
            raceTime = Time.time - lapStartTime;
            timerText.text = "Time: " + raceTime.ToString("F2") + "s";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ensure the trigger works only if the player crosses the start line
        if (other.CompareTag("Player") && other.transform == startLine)
        {
            if (!raceStarted)
            {
                // Start the race
                raceStarted = true;
                lapStartTime = Time.time;
                Debug.Log("Race Started!");
            }
            else
            {
                currentLap++;

                if (currentLap >= totalLaps)
                {
                    // Race complete
                    raceStarted = false;
                    Debug.Log("Race Completed! Final Time: " + raceTime.ToString("F2") + "s");
                    lapText.text = "Race Completed!";
                }
                else
                {
                    // Continue to the next lap
                    lapStartTime = Time.time;
                    UpdateLapText();
                    Debug.Log("Lap " + currentLap + " completed. Starting lap " + (currentLap + 1));
                }
            }
        }
    }

    void UpdateLapText()
    {
        lapText.text = "Lap: " + (currentLap + 1) + " / " + totalLaps;
    }
}