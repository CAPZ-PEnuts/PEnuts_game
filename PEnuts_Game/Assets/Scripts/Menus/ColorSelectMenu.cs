using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ColorSelectMenu : MonoBehaviour {

	public GameObject bluebox;
	
	public GameObject redbox;
	
	public GameObject multi;
	
	public GameObject ColorSelectorCanvas;
    
	private void Start()
	{
		if(multi.activeInHierarchy)
			multi.SetActive(false);
	}
    
	// Use this for initialization
	public void BlueVision()
	{
		bluebox.SetActive(true);
		redbox.SetActive(false);
		multi.SetActive(true);
		ColorSelectorCanvas.SetActive(false);
	}

	public void RedVision()
	{
		bluebox.SetActive(false);
		redbox.SetActive(true);
		multi.SetActive(true);
		ColorSelectorCanvas.SetActive(false);
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
