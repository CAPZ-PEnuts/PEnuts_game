using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rendererenable : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().enabled = !other.GetComponent<Renderer>().enabled; 
        other.GetComponentInChildren<Renderer>().enabled = !other.GetComponent<Renderer>().enabled;
    }
}
