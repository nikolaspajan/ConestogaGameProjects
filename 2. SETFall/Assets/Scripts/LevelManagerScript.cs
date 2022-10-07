using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public static LevelManagerScript instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;
    public GameObject loseMenuUI;
    public static int lives = 3;

    [Header("Treasure")]
    public static int totalPoints = 2000;
    int pointsTreasure = 2000;
    int losePointsDeath = 500;
    int losePointsRandom;
    public Text pointText;
    public Text livesText;

    private void Awake()
    {
        //get the instance and set a random points lose and set the total points and lives
        instance = this;
        losePointsRandom = Random.Range(100, 300);
        pointText.text = "Points: " + totalPoints;
        livesText.text = "Lives: " + lives;
    }
    public void Respawn()
    {
        //respawn the player at the respawn point and detract their lives, potentially turn the game over screen if they hit 0 lives
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        lives -= 1;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
            Time.timeScale = 0f;
            loseMenuUI.SetActive(true);
        }
    }

    public void IncreasePointsTreasure()
    {
        //increase points if they pickup treasure
        totalPoints += pointsTreasure;
        pointText.text = "Points: " + totalPoints;
    }

    public void DecreasePointsDeath()
    {
        //decrease points if they die
        totalPoints -= losePointsDeath;
        pointText.text = "Points: " + totalPoints;
    }

    public void DecreasePointsRandom()
    {
        //decrease points if they get hit or land in tar
        totalPoints -= losePointsRandom;
        pointText.text = "Points: " + totalPoints;
    }
}
