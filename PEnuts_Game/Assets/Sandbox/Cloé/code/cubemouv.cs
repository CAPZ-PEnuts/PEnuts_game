using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemouv : MonoBehaviour {

    private Vector3 mouv = new Vector3(0, 0, 0);
    
    void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<caissePlayer>().Caisse = this;            
            mouv.y += 0.01f;
            transform.position += mouv;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation; 

        }
	}

    void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<caissePlayer>().Caisse = null;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
	}
}
