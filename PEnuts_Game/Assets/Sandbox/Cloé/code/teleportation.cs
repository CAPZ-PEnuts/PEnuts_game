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
        if (other.gameObject == player)
            SceneManager.LoadScene(scenename);
    }
}

