using UnityEngine;

public class GameState : MonoBehaviour
{
    public int hitCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            hitCount++;
            Object.FindFirstObjectByType<GameManager>().AddLives();
            if (hitCount >= 5)
            {
                Debug.Log("Game Over!");
                Time.timeScale = 0;
                Object.FindFirstObjectByType<GameManager>().GameOver();
                

            }
        }
    }
}
