using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class changercamera : NetworkBehaviour {

    Camera Main;
    Camera cameraToGo;

    public void Start()
    {
        if (Application.loadedLevelName == "Level5")
        {
            Main = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            cameraToGo = GameObject.FindWithTag("camera2").GetComponent<Camera>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isLocalPlayer && other.gameObject.tag == "tp")
        {
            Main.enabled = !Main.enabled;
            cameraToGo.enabled = !cameraToGo.enabled; 
        }
    }

}
