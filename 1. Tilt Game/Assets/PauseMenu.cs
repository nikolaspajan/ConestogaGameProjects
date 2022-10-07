using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(GameObject.Find("Platform1"));
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(GameObject.Find("Platform2"));
            SceneManager.LoadScene(2);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Destroy(GameObject.Find("Platform3"));
            SceneManager.LoadScene(3);
        }

        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void BackToMainMenu()
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

        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    } 

    public void LoadLevel(int whatButton)
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
        if(whatButton == 1)
        {
            SceneManager.LoadScene(1);
        }
        if (whatButton == 2)
        {
            SceneManager.LoadScene(2);
        }
        if (whatButton == 3)
        {
            SceneManager.LoadScene(3);
        }
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
}
