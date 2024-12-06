using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public TextMeshProUGUI instructionsText; // Add this to show instructions

    private bool isPaused = false;

    void Start()
    {
        ShowStartMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                ShowPauseMenu();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ShowStartMenu()
    {
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f; // Pause the game at the start
        instructionsText.text = "Welcome to the Race Game!\n\n" +
           "Instructions:\n" +
           "- Complete as many laps as you can in 2 minutes.\n" +
           "- Avoid obstacles and don't fall off the road.\n\n" +
           "Press 'Start' to begin!";
        Time.timeScale = 0f; // Pause the game at the start
    }

    public void ShowPauseMenu()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pause the game when the menu is shown
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f; // Start the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
