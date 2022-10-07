using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime = 45f;
    public Text timeText;
    public GameObject loseMenuUI;

    private void Update()
    {
        //go do every second until it hits zero and ends the game
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0f;
            loseMenuUI.SetActive(true);
        }
        timeText.text = "Timer: " + currentTime.ToString("0");
    }
}
