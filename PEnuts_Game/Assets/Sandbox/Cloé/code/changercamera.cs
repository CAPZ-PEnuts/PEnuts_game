using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class changercamera : NetworkBehaviour {

    Camera Main;
    Camera cameraToGo;

    public void Start()
    {
        Main = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cameraToGo = GameObject.FindWithTag("camera2").GetComponent<Camera>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isLocalPlayer && other.gameObject.tag == "tp")
        {
            Main.enabled = false;
            cameraToGo.enabled = true; 
        }
    }

}
