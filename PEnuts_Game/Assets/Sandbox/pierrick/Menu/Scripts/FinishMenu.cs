using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{

	private GameObject multi;

	public void LoadMenu(string Menu)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(Menu);
		NetworkManager.Shutdown();
		multi.SetActive(false);
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

