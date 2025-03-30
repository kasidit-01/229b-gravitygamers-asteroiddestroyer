
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
        Time.timeScale = 0f; // ��ش�����͹�����
        gameIsOver = false;
        gameOverScreenUI.SetActive(false); // ��͹ Game Over Screen ���͹�����
        gameWinScreenUI.SetActive(false);
        creditScene.SetActive(false);
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    

    public void PlayGame()
    {
        titleScreenUI.SetActive(false); // ��͹ Title Screen
        Time.timeScale = 1f; // �������
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (gameIsOver) return;

        gameIsOver = true;
        Time.timeScale = 0f; // ��ش���������
        gameOverScreenUI.SetActive(true); // �ʴ� Game Over Screen
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f; // ����������Թ�������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ��Ŵ Scene �Ѩ�غѹ���� (Restart)
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        gameWinScreenUI.SetActive(true);
    }
    public void AddLives()  // ���¡��ѧ��ѹ���������ء�Һҵ�����ͧ
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