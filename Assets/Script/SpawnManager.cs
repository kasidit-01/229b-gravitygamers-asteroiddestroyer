using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    void Start()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
    }

    void Update()
    {
        if (currentWave >= waveConfigurations.Length)
            return;

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                Debug.Log("All waves completed!");
                Object.FindFirstObjectByType<GameManager>().WinGame();
            }
            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
        }
    }
}
