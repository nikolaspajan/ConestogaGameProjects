using UnityEngine;
using Photon.Pun;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class EndOfScreen : MonoBehaviour
{
    public static int whatLevel = 0;
    PhotonView view;
    private string dbName;
    private int pointsFromDB;

    private void Start()
    {
        dbName = "URI=file:" + Application.dataPath + "/Stats.db";
        view = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //either reload the level or open the win screen and reset the variables
        if (collision.gameObject.CompareTag("End"))
        {
            if (whatLevel != 2)
            {
                view.RPC("StartNewLevel", RpcTarget.All, "FirstLevel");
            }
            else
            {
                getPointsDB();
                //if (!view.IsMine)
                if(LevelManagerScript.totalPoints >= pointsFromDB)
                {
                    view.RPC("StartNewLevel", RpcTarget.Others, "LoseScreen");
                    SceneManager.LoadScene("WinScreen");
                }
                else
                {
                    view.RPC("StartNewLevel", RpcTarget.Others, "WinScreen");
                    SceneManager.LoadScene("LoseScreen");
                }              
            }
        }
    }

    public void getPointsDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM playerstats;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        pointsFromDB = (int)reader["points"];
                    reader.Close();
                }
            }

            connection.Close();
        }
    }

    [PunRPC]
    void StartNewLevel(string levelName)
    {
        whatLevel += 1;
        PhotonNetwork.LoadLevel(levelName);
    }
}
