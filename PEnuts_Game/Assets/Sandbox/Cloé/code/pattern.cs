using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattern : MonoBehaviour {

    private Vector3 position;
    public int borddroit;
    public int bordgauche; 

	// Use this for initialization
	void Start () {
        position = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * -20 * Time.deltaTime);

	}
}
