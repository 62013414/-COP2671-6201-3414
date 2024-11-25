using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public Transform startLine; // Drag the Start Line object here
    public TextMeshProUGUI timerText; // Drag your timer TextMeshPro UI element here
    public TextMeshProUGUI lapText; // Drag your lap count TextMeshPro UI element here

    private float timer = 0f;
    private bool raceStarted = false;
    private int currentLap = 0;
    public int totalLaps = 2;

    void Start()
    {
        timerText.text = "Time: 0.00s";
        lapText.text = "Lap: 0 / " + totalLaps;
    }

    void Update()
    {
        // Update timer only if the race has started
        if (raceStarted)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2") + "s";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected at startLine");

            // Start the race if it hasn’t started
            if (!raceStarted)
            {
                raceStarted = true;
                currentLap = 1;
                lapText.text = "Lap: " + currentLap + " / " + totalLaps;
                Debug.Log("Race Started!");
            }
            else
            {
                if (currentLap < totalLaps)
                {
                    currentLap++;
                    lapText.text = "Lap: " + currentLap + " / " + totalLaps;
                    Debug.Log("Lap " + currentLap + " completed!");
                }
                else
                {
                    raceStarted = false;
                    Debug.Log("Race Finished!");
                    timerText.text = "Final Time: " + timer.ToString("F2") + "s";
                }
            }
        }
    }
}
