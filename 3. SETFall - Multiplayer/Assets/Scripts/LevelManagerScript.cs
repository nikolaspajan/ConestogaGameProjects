using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Mono.Data.Sqlite;

public class LevelManagerScript : MonoBehaviour
{
    public static LevelManagerScript instance;
    private string dbName;

    public Transform respawnPoint;
    public static int lives = 3;
    PhotonView view;

    [Header("Treasure")]
    public static int totalPoints = 2000;
    int pointsTreasure = 2000;
    int losePointsDeath = 500;
    int losePointsRandom;
    public Text pointText;
    public Text livesText;

    private void Start()
    {
        //get the instance and set a random points lose and set the total points and lives
        instance = this;
        dbName = "URI=file:" + Application.dataPath + "/Stats.db";
        losePointsRandom = Random.Range(100, 300);
        pointText.text = "Points: " + totalPoints;
        livesText.text = "Lives: " + lives;
        view = GetComponent<PhotonView>();
        changePoints();
        if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
        {
            PhotonNetwork.Instantiate("Player", respawnPoint.position, Quaternion.identity);
        }      
    }
    public void Respawn()
    {
        //respawn the player at the respawn point and detract their lives, potentially turn the game over screen if they hit 0 lives
        lives -= 1;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
            Time.timeScale = 0f;
            view.RPC("GameOver", RpcTarget.All);
        }
    }

    public void IncreasePointsTreasure()
    {
        //increase points if they pickup treasure
        totalPoints += pointsTreasure;
        pointText.text = "Points: " + totalPoints;
        changePoints();
    }

    public void DecreasePointsDeath()
    {
        //decrease points if they die
        totalPoints -= losePointsDeath;
        pointText.text = "Points: " + totalPoints;
        changePoints();
    }

    public void DecreasePointsRandom()
    {
        //decrease points if they get hit or land in tar
        totalPoints -= losePointsRandom;
        pointText.text = "Points: " + totalPoints;
        changePoints();
    }

    public void changePoints()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE playerstats SET points = " + totalPoints + ";";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    [PunRPC]
    void GameOver()
    {
        if (lives == 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
        else
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
