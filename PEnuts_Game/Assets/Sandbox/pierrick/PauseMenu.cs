using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class PauseMenu : MonoBehaviour
{

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
    }

    public void Disconnect()
    {
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0,
            networkManager.OnDropConnection);
        networkManager.StopHost();
    }
}
