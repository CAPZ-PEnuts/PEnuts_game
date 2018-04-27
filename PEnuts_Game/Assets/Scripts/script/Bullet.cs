using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 
public class Bullet : NetworkBehaviour
{
   void OncollisionEnter(Collision collision)
    {
        Debug.Log("yes");
        var hit = collision.gameObject; 
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
