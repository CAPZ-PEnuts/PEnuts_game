using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportation : MonoBehaviour
{
    public GameObject player;
    public string scenename;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        Component pc = other.gameObject.GetComponent("PlayerController");
        if (pc != null)
        {
            Debug.Log("Teleported");
            SceneManager.LoadScene(scenename);
        }
    }
}

