using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displaytext : MonoBehaviour {

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            this.GetComponent<Renderer>().enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        this.GetComponent<Renderer>().enabled = false;
    }
}
