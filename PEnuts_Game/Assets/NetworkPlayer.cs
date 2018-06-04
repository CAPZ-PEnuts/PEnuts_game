using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkPlayer : NetworkBehaviour {

    public int id = 0;
    public bool client = false;

    public GameObject playerObjectAsset;
    public GameObject playerObject;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public override void OnStartLocalPlayer()
    {
        client = true;
    }

    public void Spawn()
    {
        playerObject = Instantiate(playerObjectAsset);
        NetworkServer.SpawnWithClientAuthority(playerObject, this.gameObject);
        CmdSpawn(playerObject);
    }
    [Command] public void CmdSpawn(GameObject go)
    {
        RpcSpawn(go);
    }
    [ClientRpc] public void RpcSpawn(GameObject go)
    {
        playerObject = go;
        playerObject.GetComponent<PlayerController>().local = isLocalPlayer;
        if (id == 1)
        {
            go.transform.position = GameObject.Find("SceneInfo").GetComponent<SceneInfo>().position1;
        }
        else if (id == 2)
        {
            go.transform.position = GameObject.Find("SceneInfo").GetComponent<SceneInfo>().position2;
        }
    }

    public void ChangeScene(string name)
    {
        CmdChangeScene(name);
    }
    [Command] public void CmdChangeScene(string name)
    {
        NetworkManager.singleton.ServerChangeScene(name);
    }

}
