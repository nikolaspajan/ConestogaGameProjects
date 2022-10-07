using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    public Text countDownTimer;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownTimer.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Destroy(GameObject.Find("Platform1"));
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Destroy(GameObject.Find("Platform2"));
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Destroy(GameObject.Find("Platform3"));
            }
            SceneManager.LoadScene(0);
            currentTime = 0;
        }
    }
}
