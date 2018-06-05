using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking; 
public class teleportation : NetworkBehaviour
{
    public GameObject player;
    public string scenename;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Triggered");
        Component pc = other.gameObject.GetComponent("PlayerController");
        if (pc != null)
        {
            Debug.Log("Teleported");
            
            //SceneManager.LoadScene(scenename);

            foreach (GameObject p in GameObject.FindGameObjectsWithTag("NetworkPlayer"))
            {
                NetworkPlayer player = p.GetComponent<NetworkPlayer>();
                if (player.id == 1)
                {
                    player.ChangeScene(scenename);
                }
            }
        }
    }
}

