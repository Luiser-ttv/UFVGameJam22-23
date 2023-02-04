using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timerDuration = 60.0f;
    public TextMeshProUGUI timerText;
    private float timerStartTime;

    void Start()
    {
        timerStartTime = Time.time;
    }

    void Update()
    {
        float timeRemaining = timerDuration - (Time.time - timerStartTime);
        timerText.text = timeRemaining.ToString("0.0");

        if (timeRemaining <= 0)
        {
            // Detener la escena aqui
            Time.timeScale = 0;
        }
    }
}

