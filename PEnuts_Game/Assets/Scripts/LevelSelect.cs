using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public GameObject gui;
    public GameObject waiting;

    public void Start()
    {
        //Debug.Log(GameObject.FindGameObjectWithTag("NetworkPlayer1"));
    }

    public void Update()
    {
        foreach(GameObject p in GameObject.FindGameObjectsWithTag("NetworkPlayer"))
        {
            NetworkPlayer player = p.GetComponent<NetworkPlayer>();
            if (player.client && player.id == 2)
            {
                gui.SetActive(false);
                waiting.SetActive(true);
            }
        }
        
    }

    public void GoToLevel(string name)
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("NetworkPlayer"))
        {
            NetworkPlayer player = p.GetComponent<NetworkPlayer>();
            if (player.id == 1)
            {
                player.ChangeScene(name);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
