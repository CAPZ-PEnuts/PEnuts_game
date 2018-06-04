using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changercamera : MonoBehaviour {

    public Camera Main;
    public Camera cameraToGo; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Main.enabled = false;
            cameraToGo.enabled = true; 
        }
    }

}
