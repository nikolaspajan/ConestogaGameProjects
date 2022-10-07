using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void MainMenu()
    {
        //load the main menu scene
        SceneManager.LoadScene(0);
    }
}
