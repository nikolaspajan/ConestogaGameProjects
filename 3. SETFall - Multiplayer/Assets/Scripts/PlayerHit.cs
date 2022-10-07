using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the play gets hit by a log, destroy the log, decrease points and play the log hit sound
        if (collision.gameObject.CompareTag("Log"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<Audio>().Play("LogHit");
            LevelManagerScript.instance.DecreasePointsRandom();
        }
    }
}
