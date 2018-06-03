using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawncube : MonoBehaviour
{

	public GameObject caissespawn;

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Killzone")
		{
			transform.position = caissespawn.transform.position; 
		}
	}
}
