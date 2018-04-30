using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceStart : MonoBehaviour {

	public Transform testobj;
	
	// Use this for initialization
	void Start ()
	{
		Instantiate(testobj);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
