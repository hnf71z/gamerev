using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 60f; // Contoh: 60 detik
    private bool isGameOver = true;

    void Update()
    {
        if (isGameOver && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if(isGameOver)
        {
            remainingTime = 0;
            timerText.text = "00:00";
            // Ganti "GameOverScene" dengan nama scene tujuan kamu
            isGameOver = false;
            SceneManager.LoadScene("gameover");
        }
    }
}
