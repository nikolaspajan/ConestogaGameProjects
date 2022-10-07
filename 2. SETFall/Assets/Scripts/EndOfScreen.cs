using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfScreen : MonoBehaviour
{
    public static int whatLevel = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //either reload the level or open the win screen and reset the variables
        if (collision.gameObject.CompareTag("Player"))
        {
            whatLevel += 1;
            if (whatLevel != 4)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(2);
                whatLevel = 0;
                Timer.currentTime = 45f;
                LevelManagerScript.lives = 3;
                LevelManagerScript.totalPoints = 2000;
                GetSeedValue.seedValue = 0;
            }
        }
    }
}
