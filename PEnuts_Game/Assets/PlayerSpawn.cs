using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerSpawn : NetworkBehaviour {

	// Use this for initialization
	public GameObject player;
	private bool spawned = false;
	void Start ()
	{
		Network.Connect("127.0.0.1", 232);
		if(SceneManager.GetActiveScene().name == "Level2")
		{
			print("LUL");
			Instantiate(player, player.transform.position, player.transform.rotation);
		}
	}
	// Update is called once per frame
	void Update () {
		
			if(SceneManager.GetActiveScene().name == "Level2" && !spawned)
			{
				print("LUL");
				Network.Instantiate(player, player.transform.position, player.transform.rotation, 0);
				spawned = true;
			}
		
		
	}
}
