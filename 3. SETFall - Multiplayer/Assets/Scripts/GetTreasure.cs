using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasure : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player gets the treasure/coin, destroy the treasure, play a the treasure sound and increase points
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<Audio>().Play("TreasureGet");
            LevelManagerScript.instance.IncreasePointsTreasure(); 
        }
    }
}
