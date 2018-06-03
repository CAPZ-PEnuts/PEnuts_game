using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilzone : MonoBehaviour 
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("degat");
        var hit = other.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(1000000);
        }
    }
}
