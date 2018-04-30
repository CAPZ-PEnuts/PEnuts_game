using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caissePlayer : MonoBehaviour {

	public cubemouv Caisse;

	void changecaisse()
	{
		if (Caisse != null)
		{
			Rigidbody rb = Caisse.GetComponent<Rigidbody>();
			//on change l'objet de parent
			Caisse.transform.SetParent(this.transform); 
			//on ajoute le is kinetic à l'objet  
			rb = GetComponent<Rigidbody>();
			rb.isKinematic = true;
			//on débloque mouv x
			rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ |
			                RigidbodyConstraints.FreezeRotation;
		}
	}
}
