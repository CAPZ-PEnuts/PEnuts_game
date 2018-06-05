using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Server : NetworkManager
{
    public bool hasToSpawn1 = false;
    public bool hasToSpawn2 = false;

    public int gameId = 0;
    public bool firstGame = true;
    public int playerId = 0;

    public GameObject player1Asset;
    private GameObject player1;
    private NetworkConnection player1Connection;
    private short player1ControllerId;

    public GameObject player2Asset;
    private GameObject player2;
    private NetworkConnection player2Connection;
    private short player2ControllerId;



    public void Disconnect()
    {
        if (matchMaker)
        {
            matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, OnDropConnection);
        }
        StopHost();
        Destroy(gameObject);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        ClientScene.Ready(conn);
        ClientScene.AddPlayer(conn, 0);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        Disconnect();
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        if(gameId >= 2)
        {
            firstGame = false;
        }

        gameId++;

        hasToSpawn1 = true;
        hasToSpawn2 = true;
    }

    void Update()
    {
        if(player1Connection != null) //&& player2Connection != null)
        {
            if (hasToSpawn1 && player1Connection.isReady)
            {
                if(SceneManager.GetActiveScene().name != "LevelSelect" && SceneManager.GetActiveScene().name != "FinishMenu")
                {
                    player1.GetComponent<NetworkPlayer>().Spawn();
                }
                hasToSpawn1 = false;
            }
            if (hasToSpawn2 && player2Connection.isReady)
            {
                if (SceneManager.GetActiveScene().name != "LevelSelect" && SceneManager.GetActiveScene().name != "FinishMenu")
                {
                    player2.GetComponent<NetworkPlayer>().Spawn();
                }
                hasToSpawn2 = false;
            }
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        if (playerId == 0)
        {
            SpawnPlayer1(conn, playerControllerId);
        }
        else if (playerId == 1)
        {
            SpawnPlayer2(conn, playerControllerId);
        }

        playerId++;
    }

    private GameObject SpawnPlayer1(NetworkConnection conn = null, short playerControllerId = 0)
    {
        player1Connection = conn;
        player1ControllerId = playerControllerId;

        player1 = Instantiate(player1Asset);
        player1.name = player1Asset.name;

        NetworkServer.AddPlayerForConnection(player1Connection, player1, player1ControllerId);

        return player1;
    }

    private GameObject SpawnPlayer2(NetworkConnection conn = null, short playerControllerId = 0)
    {
        player2Connection = conn;
        player2ControllerId = playerControllerId;

        player2 = Instantiate(player2Asset);
        player2.name = player2Asset.name;
        
        NetworkServer.AddPlayerForConnection(player2Connection, player2, player2ControllerId);

        return player2;
    }
}
