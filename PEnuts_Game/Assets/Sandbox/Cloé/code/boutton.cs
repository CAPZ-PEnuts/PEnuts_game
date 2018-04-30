using System.Collections;
using System.Threading; 
using System.Collections.Generic;
using UnityEngine;

public class boutton : MonoBehaviour {

    public GameObject player;
    public porte porte;
    public int place; 

	// Use this for initialization
	void Start()
    {
        porte.mybut[place] = this; 
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //if (Input.GetKeyDown(KeyCode.F))
                porte.activebutton(this); 
        }
    }
}
