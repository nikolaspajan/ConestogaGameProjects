using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerDeath : MonoBehaviour
{
    public GameObject attach;
    public GameObject playerPrefab;
    public Transform respawnPoint;
    PhotonView view;
    private void Awake()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint").transform;
        view = GetComponent<PhotonView>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (view.IsMine)
        {
            //if the player gets hits, destroy and respawn the player, decrease points and lives and play a sound
            if (collision.gameObject.CompareTag("Scorpion") || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Lake"))
            { 
                LevelManagerScript.instance.DecreasePointsDeath();
                LevelManagerScript.instance.Respawn();

                PhotonNetwork.Destroy(gameObject);

                if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
                {
                    PhotonNetwork.Instantiate("Player", respawnPoint.position, Quaternion.identity);
                }

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
}
