using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpvector0 : MonoBehaviour {

	public Vector3 where2go;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			other.transform.position = where2go;
	}
}
