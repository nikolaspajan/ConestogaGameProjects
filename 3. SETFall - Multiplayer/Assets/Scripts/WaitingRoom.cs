using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class WaitingRoom : MonoBehaviourPunCallbacks
{
    private PhotonView view;
    private int playerCount;
    private int roomSize;

    [SerializeField]
    private Text playerCountText;

    private bool startGame;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        PlayerCountUpdate();
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        playerCountText.text = playerCount + ":" + roomSize;

        if(playerCount == roomSize)
        {
            startGame = true;
        }
        else
        {
            startGame = false;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerCountUpdate();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerCountUpdate();
    }

    private void Update()
    {
        WaitingForPlayers();
    }

    void WaitingForPlayers()
    {
        if (startGame)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}
