using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        //starts the game and resets the time scale from the pause and game over menu
        Time.timeScale = 1f;
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void QuitGame()
    {
        //quit the game
        Application.Quit();
    }
}
