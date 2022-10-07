using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static float currentTime = 45f;
    public Text timeText;
    PhotonView view;
    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        //go do every second until it hits zero and ends the game
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            view.RPC("TimerDone", RpcTarget.All);
        }
        timeText.text = "Timer: " + currentTime.ToString("0");
    }

    [PunRPC]
    void TimerDone()
    {
        currentTime = 0;
        Time.timeScale = 0f;
        SceneManager.LoadScene("LoseScreen");
    }
}
