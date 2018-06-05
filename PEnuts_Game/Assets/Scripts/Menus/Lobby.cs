using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class Lobby : MonoBehaviour {

    public Text status;
    public InputField roomName;
    private NetworkManager networkManager;

    void Start()
    {
        networkManager = GameObject.Find("NetworkManager").GetComponent<Server>();

        //networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        InvokeRepeating("RefreshRoomList", 0, 3f);
    }

    /**
     * MATCH CREATION
     **/

    public void OnMatchCreate()
    {
        var name = roomName.GetComponent<InputField>().text;
        roomName.GetComponent<InputField>().text = "";
        if (name != null)
        {
            networkManager.matchMaker.CreateMatch(name, 2, true, "", "", "", 0, 0, OnMatchCreated);
            RefreshRoomList();
        }
    }

    public void OnMatchCreated(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            networkManager.StartHost(matchInfo);
        }
    }

    /**
     * MATCH JOIN
     **/

    public void RefreshRoomList()
    {
        status.text = "Loading...";
        networkManager.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
    }

    private void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        status.text = "";
        if (!success)
        {
            status.text = "An issue occured with your connection...";
            return;
        }


        int id = 1;

        foreach (var match in matchList)
        {
            var roomGameObject = GameObject.Find("room_" + id).GetComponentInChildren<Button>();
            roomGameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(match.name);
            roomGameObject.gameObject.SetActive(true);
            roomGameObject.onClick.RemoveAllListeners();
            //Debug.Log(roomGameObject.GetComponent<Button>());
            roomGameObject.onClick.AddListener(
                delegate
                {
                    status.text = "Joining...";
                    networkManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, OnMatchJoined);
                });
            id++;
        }

        //status.text
        if (id == 1)
            status.text = "No rooms for the time...";

        else
            status.text = "[" + (id - 1) + "/10] rooms";

        //disable empty rooms
        while (id <= 10)
        {
            var roomGameObject = GameObject.Find("room_" + id).GetComponentInChildren<Button>();
            roomGameObject.GetComponentInChildren<TextMeshProUGUI>().SetText("");
            roomGameObject.onClick.RemoveAllListeners();
            roomGameObject.gameObject.SetActive(false);
            id++;
        }
    }

    public void OnMatchJoined(bool success, string extendInfo, MatchInfo matchInfo)
    {
        if (success)
            networkManager.StartClient(matchInfo);
    }

}
