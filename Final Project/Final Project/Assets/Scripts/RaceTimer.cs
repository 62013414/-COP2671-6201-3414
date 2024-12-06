using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public float raceDuration = 12f; // 2 minutes
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI messageText;
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button quitButton;

    private float remainingTime;
    private int completedLaps = 0;
    private bool raceActive = true;
    private bool firstPass = true;

    void Start()
    {
        remainingTime = raceDuration;
        UpdateTimerUI();
        UpdateLapUI();
        messageText.text = "LETS GO!!";
        Invoke("ClearMessage", 1f);
        gameOverPanel.SetActive(false);
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

    public void PassFinishLine()
    {
        if (raceActive)
        {
            if (firstPass)
            {
                messageText.text = "Game Started!";
                firstPass = false;
            }
            else
            {
                completedLaps++;
                UpdateLapUI();
                messageText.text = "Lap Completed!";
            }
            Invoke("ClearMessage", 2f);
        }
    }

    public void CrashObstacle()
    {
        if (raceActive)
        {
            remainingTime -= 10f;
            messageText.text = "10 Seconds Penalty!";
            Invoke("ClearMessage", 2f);
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
        messageText.text = "Game Over! Total Laps: " + completedLaps;
        EndGame();
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    

    public void QuitGame()
    {
        Debug.Log("Quit button clicked!");
        Application.Quit();
    }
}
