using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject attach;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player gets hits, destroy and respawn the player, decrease points and lives and play a sound
        if (collision.gameObject.CompareTag("Scorpion") || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Lake"))
        {
            Destroy(gameObject);
            LevelManagerScript.instance.DecreasePointsDeath();
            LevelManagerScript.instance.Respawn();
            attach.gameObject.GetComponent<PlayerMovement>().attached = false;

            if (collision.gameObject.CompareTag("Scorpion"))
            {
                FindObjectOfType<Audio>().Play("ScorpionSting");
            }
            if (collision.gameObject.CompareTag("Fire"))
            {
                FindObjectOfType<Audio>().Play("Fire");
            }
            if (collision.gameObject.CompareTag("Lake"))
            {
                FindObjectOfType<Audio>().Play("WaterSplash");
            }
        }
    }
}
