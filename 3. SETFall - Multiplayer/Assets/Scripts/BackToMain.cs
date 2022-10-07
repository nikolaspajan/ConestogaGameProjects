using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void MainMenu()
    {
        EndOfScreen.whatLevel = 0;
        Timer.currentTime = 45f;
        LevelManagerScript.lives = 3;
        LevelManagerScript.totalPoints = 2000;

        StartCoroutine(MainMenuDisconnect());
    }

    IEnumerator MainMenuDisconnect()
    {
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom)
            yield return null;
        SceneManager.LoadScene("MainMenu");
    }
}
