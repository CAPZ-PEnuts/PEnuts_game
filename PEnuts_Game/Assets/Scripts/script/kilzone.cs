using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilzone : MonoBehaviour 
{

    void OncollisionEnter(Collision collision)
    {
        Debug.Log("yes");
        var hit = collision.gameObject;
        hit.GetComponent<Health>().TakeDamage(100);



    }
}
