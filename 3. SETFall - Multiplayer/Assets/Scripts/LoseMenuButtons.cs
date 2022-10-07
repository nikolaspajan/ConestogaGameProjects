using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoseMenuButtons : MonoBehaviour
{
    public void GoToMainMenu()
    {
        //loads the main menu and resets the game
        SceneManager.LoadScene("MainMenu");
        EndOfScreen.whatLevel = 0;
        Timer.currentTime = 45f;
        LevelManagerScript.lives = 3;
        LevelManagerScript.totalPoints = 2000;
    }
    public void QuitGame()
    {
        //quit the game
        Application.Quit();
    }
}
