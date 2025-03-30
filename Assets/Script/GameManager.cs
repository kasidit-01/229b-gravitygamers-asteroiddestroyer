
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject creditScene;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreenUI;     
    public GameObject gameOverScreenUI;  
    public GameObject gameWinScreenUI;
    private int currentLives = 0;
    private int maxLives = 5;

    private bool gameIsOver = false;
    private void Awake()
    {
        Time.timeScale = 0f; 
        gameIsOver = false;
        gameOverScreenUI.SetActive(false); 
        gameWinScreenUI.SetActive(false);
        creditScene.SetActive(false);
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    

    public void PlayGame()
    {
        titleScreenUI.SetActive(false); 
        Time.timeScale = 1f; 
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (gameIsOver) return;

        gameIsOver = true;
        Time.timeScale = 0f; 
        gameOverScreenUI.SetActive(true); 
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        gameWinScreenUI.SetActive(true);
    }
    public void AddLives()  
    {
        currentLives++;
        UpdateLivesUI();

        if (currentLives >= maxLives)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI()
    {
        if (scoreText != null)
        {
            int attemptsLeft = maxLives - currentLives;
            scoreText.text = "Lives: " + attemptsLeft.ToString();
        }
    }
    public void credit()
    {
        titleScreenUI.SetActive(false);
        gameWinScreenUI.SetActive(false);
        creditScene.SetActive(true);
    }
}