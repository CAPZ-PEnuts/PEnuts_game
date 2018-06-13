using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ColorSelectMenu :NetworkBehaviour {

	public GameObject bluebox;
	
	public GameObject redbox;
	
	public GameObject ColorSelectorCanvas;


    public bool isblue = true;


    public GameObject hostCanvas;

    public void Update()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("NetworkPlayer"))
        {
            NetworkPlayer player = p.GetComponent<NetworkPlayer>();
            if (player.client && player.id == 2)
            {
                hostCanvas.SetActive(false);
            }
            if (player.client && player.id == 1)
            {
                hostCanvas.SetActive(true);
            }
        }
    }

    // Use this for initialization
    public void BlueVision()
	{
		if (bluebox != null)
			bluebox.SetActive(true);
		
		if (redbox != null)
			redbox.SetActive(false);
		
		ColorSelectorCanvas.SetActive(false);
        /*
        GameObject[] bluboxx = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in bluboxx)
        {
            if (player.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                player.GetComponent<PlayerController>().isblue(true); 
            }
        }
        */
    }

	public void RedVision()
	{
		if (bluebox != null)
			bluebox.SetActive(false);
		
		if (redbox != null)
			redbox.SetActive(true);
       
		ColorSelectorCanvas.SetActive(false);
        isblue = false;
        /*
        GameObject[] bluboxx = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in bluboxx)
        {
            if (player.GetComponent<PlayerController>().local) 
            {
                player.GetComponent<PlayerController>().isblue(false);
                Debug.Log("STEPONE");
            }
            else
            {
                Debug.Log("NOONE");
            }
        }
        */
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
	
	public void LoadMenu(string Menu)
	{
		SceneManager.LoadScene(Menu);
		NetworkManager.Shutdown();
		/*
		MatchInfo matchInfo = networkManager.matchInfo;
		networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0,
		    networkManager.OnDropConnection);
		networkManager.StopHost();
		 */
	}
    
    
	public void Quit()
	{
		Application.Quit();
	}
}
