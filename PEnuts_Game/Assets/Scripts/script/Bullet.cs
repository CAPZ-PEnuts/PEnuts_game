using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 


public class Bullet : NetworkBehaviour
{
    // private GameObject blubox;
    // private GameObject redbox;

    private bool isbluee = true;
    public bool Isbluee { get { return isbluee; } set { isbluee = value; } }
    private void Start()
    {
        Debug.Log("enter" + isbluee);
        if(!isbluee)
        {
            Debug.Log("ALORS2" + isbluee);
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        /*
        GameObject[] bluboxx = GameObject.FindGameObjectsWithTag("blubox");
        if(bluboxx.Length != 0)
            blubox = bluboxx[0];
            
        GameObject[] redboxx = GameObject.FindGameObjectsWithTag("redbox");
        if (redboxx.Length != 0)
            redbox = redboxx[0];
            
        if (redboxx.Length != 0 && redbox.activeInHierarchy && player.GetComponent<NetworkIdentity>().isLocalPlayer)
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        */


    }
    public bool Degatred = true; 
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if (Degatred)
        {
            var hit = collision.gameObject;
            if (isbluee)
            {
                var etas = hit.GetComponent<enemicontroller>();
                if (etas != null)
                    etas.etas();
            }
            else
            {
                var health = hit.GetComponent<Health>();
                if (health != null)
                    health.TakeDamage(10);
            }
        }

        Destroy(gameObject);
        /*
        Debug.Log("hit");
        if (Degatred)
        {
            var hit = collision.gameObject;
            if (redbox!= null && redbox.activeInHierarchy)
            {
                var health = hit.GetComponent<Health>();
                if (health != null)
                    health.TakeDamage(10);
            }
            
            if (blubox!= null && blubox.activeInHierarchy)
            {
                var etas = hit.GetComponent<enemicontroller>();
                if (etas != null)
                    etas.etas();
            }
        }

        Destroy(gameObject);
        */
    }

}
