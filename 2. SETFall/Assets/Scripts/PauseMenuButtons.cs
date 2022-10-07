using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject loseMenuUI;

    // Update is called once per frame
    void Update()
    {
        //the the game is over don't run this
        if(loseMenuUI.activeInHierarchy == false)
        {
            // if esc is pressed pause or unpause the game and freeze or unfreeze it
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    pauseMenuUI.SetActive(false);
                    Time.timeScale = 1f;
                    gameIsPaused = false;
                }
                else
                {
                    pauseMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    gameIsPaused = true;
                }
            }
        }
    }
    public void GoToMainMenu()
    {
        //load main menu
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        //quit the game
        Application.Quit();
    }
}
