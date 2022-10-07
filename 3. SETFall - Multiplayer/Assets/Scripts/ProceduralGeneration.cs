using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject treasure;

    [Header("Enemies")]
    public GameObject fire;
    public GameObject scorpion;
    public GameObject log;

    [Header("Obstacles")]
    public GameObject waterVine;
    public GameObject waterCrocs;
    public GameObject tarVine;

    void Start()
    {
        Generation();
    }
    void Generation()
    {
        Random.InitState(10 + EndOfScreen.whatLevel);      

        int enemySpawn = Random.Range(0, 3);
        int obstacleSpawn = Random.Range(0, 3);
        int treasureSpawn = Random.Range(0, 1);

        switch (enemySpawn)
        {
            case 0:
                SpawnObject(scorpion, Random.Range(-5f, 3f), -1.31f);
                break;
            case 1:
                SpawnObject(log, Random.Range(-5f, 3f), -1.345f);
                break;
            case 2:
                SpawnObject(fire, Random.Range(-5f, 3f), -1.31f);
                break;
            case 3:
                break;
        }

        switch (obstacleSpawn)
        {
            case 0:
                SpawnObject(waterCrocs, Random.Range(-3f, 3f), -1.58f);
                break;
            case 1:
                SpawnObject(waterVine, Random.Range(-3f, 3f), -1.57f);
                break;
            case 2:
                SpawnObject(tarVine, Random.Range(-3f, 3f), -1.57f);
                break;
            case 3:
                break;
        }

        switch (treasureSpawn)
        {
            case 0:
                SpawnObject(treasure, Random.Range(-5f, 3f), -1.2f);
                break;
            case 1:

                break;
        }
    }

    void SpawnObject(GameObject obj, float x, float y)
    {
        //create the object that is called
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}