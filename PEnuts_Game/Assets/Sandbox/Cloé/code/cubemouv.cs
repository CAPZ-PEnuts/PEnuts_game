using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemouv : MonoBehaviour {

	public GameObject player; 
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player)
		{
			other.gameObject.GetComponent<caissePlayer>().Caisse = this;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player)
		{
			other.gameObject.GetComponent<caissePlayer>().Caisse = null;
		}
	}
}
