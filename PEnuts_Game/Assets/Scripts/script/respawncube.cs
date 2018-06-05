using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawncube : MonoBehaviour
{

	public GameObject caissespawn;

	private void Update()
	{
		Vector3 v = GetComponent<Rigidbody>().velocity;
		if (v.magnitude <= 0.1 &&  (transform.rotation.eulerAngles.x > 10 || transform.rotation.eulerAngles.x < -10 || transform.rotation.eulerAngles.z > 10 || transform.rotation.eulerAngles.z < -10)  )
		{
			transform.eulerAngles = caissespawn.transform.eulerAngles;
			transform.position = caissespawn.transform.position; 
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Killzone")
		{
			transform.position = caissespawn.transform.position; 
		}
	}
}
