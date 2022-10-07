using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite; 

public class Database : MonoBehaviour
{
    private string dbName;

    void Awake()
    {
        dbName = "URI=file:" + Application.dataPath + "/Stats.db";
        CreateDB();
    }

    public void CreateDB()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS playerstats (points INTEGER);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
