using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechat_controller : MonoBehaviour
{
	public GameObject player;
	public float playerdistance; 
	private void Update()
	{
		playerdistance = Vector3.Distance(player.transform.position, transform.position);
		if (playerdistance < 20f)
		{
			transform.LookAt(player.transform.position);
			Debug.Log("proute");
		}

		
	}
}
