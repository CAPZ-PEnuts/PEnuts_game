using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;



public class HostGame : MonoBehaviour
{

    private uint roomSize = 2;

    private string roomName;

    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetRoomName(string _name)
    {
        roomName = _name;
    }

    public void CreateRoom()
    {
        if (roomName != "" && roomName != null) //should I add something to limit the number of char ?
        {
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, OnMatchCreated);
        }
    }

    public void OnMatchCreated(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            networkManager.StartHost(matchInfo);
        }
    }
    
}
