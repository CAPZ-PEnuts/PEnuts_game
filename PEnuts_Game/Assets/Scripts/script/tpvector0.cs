using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class tpvector0 : MonoBehaviour {

	public Vector3 where2go;
	
	void OnTriggerEnter(Collider other)
	{
		other.transform.position = where2go;
	}
}
