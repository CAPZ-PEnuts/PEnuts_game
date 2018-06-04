using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 


public class Bullet : NetworkBehaviour
{
    private GameObject blubox;
    private GameObject redbox;

    private void Start()
    {
        GameObject[] bluboxx = GameObject.FindGameObjectsWithTag("blubox");
        if(bluboxx.Length != 0)
            blubox = bluboxx[0];
        GameObject[] redboxx = GameObject.FindGameObjectsWithTag("redbox");
        if (redboxx.Length != 0)
            redbox = redboxx[0];
        if (redboxx.Length != 0 && redbox.activeInHierarchy)
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public bool Degatred = true; 
    void OnCollisionEnter(Collision collision)
    {
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
            else
            {
                var etas = hit.GetComponent<enemicontroller>();
                if (etas != null)
                    etas.etas();
            }
        }

        Destroy(gameObject);
    }
}
