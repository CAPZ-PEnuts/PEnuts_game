using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryShoot : MonoBehaviour {
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ShootTag")
        {
            Destroy(other.gameObject);
        }
    }
}
