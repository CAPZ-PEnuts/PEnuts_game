using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{

	public void LoadMenu(string Menu)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(Menu);
		NetworkManager.Shutdown();
		/*
		MatchInfo matchInfo = networkManager.matchInfo;
		networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0,
		    networkManager.OnDropConnection);
		networkManager.StopHost();
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
    
	public void Quit()
	{
		Application.Quit();
	}

    public void website(string websiteName)
    {
        Application.OpenURL(websiteName);
    }
}

