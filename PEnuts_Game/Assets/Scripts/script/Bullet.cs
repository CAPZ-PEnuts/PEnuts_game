using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 


public class Bullet : NetworkBehaviour
{

    public bool Degatred = true; 
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if (Degatred)
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            var etas = hit.GetComponent<enemicontroller>();
            if (health != null)
            {
                health.TakeDamage(10);
                etas.etas(); 
            }
            
        }

        Destroy(gameObject);
    }
}
