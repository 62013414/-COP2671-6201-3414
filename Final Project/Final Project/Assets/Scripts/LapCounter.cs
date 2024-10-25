using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public int totalLaps = 3;
    private int currentLap = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentLap++;
            Debug.Log("Lap " + currentLap + " completed!");

            if (currentLap >= totalLaps)
            {
                EndRace();
            }
        }
    }
        void EndRace()
        {
            // Logic to end the race, show results, or transition to next level
            Debug.Log("Race Finished! You completed all laps.");
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    
}
