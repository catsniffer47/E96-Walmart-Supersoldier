using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    public float countdownTime = 60f; // Set the countdown time in seconds

    void Start()
    {
        startTime = Time.time + countdownTime; // Set the start time to current time + countdown time
    }

    void Update()
    {
        float remainingTime = startTime - Time.time;

        if (remainingTime <= 0)
        {
            timerText.text = "0";
            LoadEndScene();
        }
        else
        {
            string seconds = ((int)remainingTime % 60).ToString();
            timerText.text = seconds;
        }
    }

    void LoadEndScene()
    {
        // Replace "EndScene" with the name of your end scene
        SceneManager.LoadScene("Game Over");
    }
}