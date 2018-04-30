using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 




public class degat : NetworkBehaviour
{

	public float cadence_de_degat = 10f;

	private float next_degat;
	
	private void OnCollisionStay(Collision collision)
	{
		if (Time.time > next_degat)
		{
			Debug.Log("degat");
			var hit = collision.gameObject;
			var health = hit.GetComponent<Health>();
			if (health != null)
			{
				health.TakeDamage(30);
			}

			next_degat = Time.time + cadence_de_degat;
		}
	}
}


