using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemicontroller : MonoBehaviour
{


	public float lookradius = 20f;
	public GameObject lumiere; 
	private GameObject player; 
	NavMeshAgent agent;
	private float distance; 
	private bool isdead = false;
	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>(); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject[] gameplayer = GameObject.FindGameObjectsWithTag("Player");
		if (gameplayer.Length != 0)
		{
			distance = Vector3.Distance(transform.position, gameplayer[0].transform.position);
			player = gameplayer[0];
			for (int i = 1; i < gameplayer.Length; i++)
				if (distance > Vector3.Distance(transform.position, gameplayer[i].transform.position))
				{
					distance = Vector3.Distance(transform.position, gameplayer[i].transform.position);
					player = gameplayer[i];
				}
		}
		if(isdead)
			Destroy(gameObject);
		//float distance = Vector3.Distance(player.transform.position, transform.position);
		if (distance <= lookradius)
		{
			//transform.LookAt(player.transform);
			agent.SetDestination(player.transform.position);
			lumiere.SetActive(true);
		}
		else
		{
			lumiere.SetActive(false);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookradius); 
	}
	
}
