using UnityEngine;
using UnityEngine.UI; // user interface

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 120f; 
    private float timeRemaining;
    public Text timerText;  // UI Text element, display timer
    public GameObject gameOverScreen;  // Reference to the "Game Over"

    void Start()
    {
        timeRemaining = timeLimit;
        gameOverScreen.SetActive(false);  // Hide the "Game Over" screen initially
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            TimeUp();
        }

        // Display timer in MM:SS format
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void TimeUp()
    {
        // Show Game Over screen
        gameOverScreen.SetActive(true);

        // Pause the game (stop time)
        Time.timeScale = 0f;

        // Optionally, you can wait a few seconds before quitting
        Invoke("QuitGame", 3f);  // Wait 3 seconds before quitting
    }

    void QuitGame()
    {
        Debug.Log("Game Over. Exiting game...");
        Application.Quit();
    }
}

