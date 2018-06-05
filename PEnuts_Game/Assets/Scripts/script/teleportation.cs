using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking; 
public class teleportation : NetworkBehaviour
{
    public GameObject player;
    public string scenename;

    private Component firstPlayer;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Triggered");
        Component pc = other.gameObject.GetComponent("PlayerController");
        if (pc != null)
        {
            if (firstPlayer == null)
            {
                firstPlayer = pc;
                Debug.Log("First Player checked portal");
            }
            else if (firstPlayer.GetInstanceID() != pc.GetInstanceID())
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
}

