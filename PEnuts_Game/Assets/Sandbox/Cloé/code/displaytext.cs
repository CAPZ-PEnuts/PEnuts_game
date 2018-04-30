using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displaytext : MonoBehaviour {

    public GameObject player; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            this.GetComponent<Renderer>().enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        this.GetComponent<Renderer>().enabled = false;
    }
}
