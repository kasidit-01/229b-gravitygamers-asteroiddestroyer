
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject creditScene;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreenUI;     // Drag the Title Screen UI Canvas here
    public GameObject gameOverScreenUI;  // Drag the Game Over Screen UI Canvas here
    public GameObject gameWinScreenUI;
    private int currentLives = 0;
    private int maxLives = 5;

    private bool gameIsOver = false;
    private void Awake()
    {
        Time.timeScale = 0f; // หยุดเกมไว้ตอนเริ่ม
        gameIsOver = false;
        gameOverScreenUI.SetActive(false); // ซ่อน Game Over Screen ไว้ตอนเริ่ม
        gameWinScreenUI.SetActive(false);
        creditScene.SetActive(false);
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    

    public void PlayGame()
    {
        titleScreenUI.SetActive(false); // ซ่อน Title Screen
        Time.timeScale = 1f; // เริ่มเกม
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (gameIsOver) return;

        gameIsOver = true;
        Time.timeScale = 0f; // หยุดเกมเมื่อแพ้
        gameOverScreenUI.SetActive(true); // แสดง Game Over Screen
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f; // ทำให้เวลาเดินตามปกติ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // โหลด Scene ปัจจุบันใหม่ (Restart)
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        gameWinScreenUI.SetActive(true);
    }
    public void AddLives()  // เรียกใช้ฟังก์ชันนี้เมื่ออุกกาบาตชนกล่อง
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