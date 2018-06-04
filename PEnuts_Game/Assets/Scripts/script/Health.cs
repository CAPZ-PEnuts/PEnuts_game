using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Health : NetworkBehaviour 
{
    
    private const int maxhealth = 100;
    
   [SyncVar(hook = "OnchangeHealth")]
    public int currentHealth = maxhealth;

    public GameObject spawn; 
    
    public RectTransform healthbar;

    public void TakeDamage(int amout)
    {
        if (isServer)
        {
            currentHealth -= amout;
            if (currentHealth <= 0)
            {
                currentHealth = maxhealth;
                RpcRspawn();
                NetworkManager.singleton.ServerChangeScene(SceneManager.GetActiveScene().name);
                Debug.Log("dead!");
            }
        }
    }

    void OnchangeHealth(int health)
    {
        healthbar.sizeDelta = new Vector2(health, healthbar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRspawn()
    {

        if (gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
        if (isLocalPlayer)
        {
            transform.position = spawn.transform.position; 
        }
    }
}
