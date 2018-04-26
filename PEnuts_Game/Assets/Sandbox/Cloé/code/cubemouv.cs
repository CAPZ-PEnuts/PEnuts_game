﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemouv : MonoBehaviour {

	public GameObject player;
    private Vector3 mouv = new Vector3(0, 0, 0);

    void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player)
		{
			other.gameObject.GetComponent<caissePlayer>().Caisse = this;
            this.GetComponent<Rigidbody>().isKinematic = true; 
            mouv.y += 0.01f;
            transform.position += mouv;             
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player)
		{
			other.gameObject.GetComponent<caissePlayer>().Caisse = null;
            transform.position -= mouv;
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
	}
}
