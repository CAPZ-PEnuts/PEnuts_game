using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject hostCanvas;
    public GameObject clientCanvas;

    public void Update()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("NetworkPlayer"))
        {
            NetworkPlayer player = p.GetComponent<NetworkPlayer>();
            if (player.client && player.id == 2)
            {
                hostCanvas.SetActive(false);
                clientCanvas.SetActive(true);
            }
            if (player.client && player.id == 1)
            {
                hostCanvas.SetActive(true);
                clientCanvas.SetActive(false);
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

    public void website(string websiteName)
    {
        Application.OpenURL("http://" + websiteName);
    }
}

