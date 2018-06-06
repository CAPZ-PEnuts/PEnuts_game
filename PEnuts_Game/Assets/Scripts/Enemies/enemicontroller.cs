using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.Experimental.Audio.Google;
//using Vuforia;
 
public class enemicontroller : MonoBehaviour
{


	public float lookradius = 20f;
	//PARTICULE 
	public GameObject lumiere;
	public GameObject virus;
	public GameObject boom;
	public GameObject darknest;
	public GameObject darkskull;
	public GameObject darkmagic;  
	public bool etas1 = true;

	private float timeetas; 
	
	private GameObject player; 
	
	public float cadence_de_degat = 10f;
	private float next_degat;
	public float distance_de_degat;

	public GameObject spwanmechant; 
	NavMeshAgent agent;
	private float distance; 
	private bool isdead = false;
	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>(); 
		virus.SetActive(false);
		darknest.SetActive(true);
		darkskull.SetActive(false);
		darkmagic.SetActive(true);
        if(boom!=null)
		    boom.SetActive(false); 
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

		if (timeetas < Time.time)
			etas1 = true; 
		if (isdead)
		{
			Destroy(gameObject);
			boom.SetActive(true);
		}
		
		//float distance = Vector3.Distance(player.transform.position, transform.position);
		if (distance <= lookradius && gameplayer.Length != 0 && etas1)
		{
			//transform.LookAt(player.transform);
			agent.SetDestination(player.transform.position);
			lumiere.SetActive(true);
		}
		else if(etas1)
		{
			lumiere.SetActive(false);
			agent.SetDestination(spwanmechant.transform.position); 
		}
		
		if (etas1)
		{
            if (virus != null)
                virus.SetActive(false);
            if (darknest != null)
                darknest.SetActive(true);
            if (darkskull != null)
                darkskull.SetActive(false);
            if(darkmagic != null)
			    darkmagic.SetActive(true);
		}
		else
		{
            if (virus != null)
                virus.SetActive(true);
            if (darknest != null)
                darknest.SetActive(false);
            if (darkskull != null)
                darkskull.SetActive(true);
            if (darkmagic != null)
                darkmagic.SetActive(false);
		}

		if (distance < distance_de_degat && etas1)
		{
			if (Time.time > next_degat && gameplayer.Length != 0)
			{
				Debug.Log("degat");
				var hit = player;
				var health = hit.GetComponent<Health>();
				if (health != null)
				{
					health.TakeDamage(30);
				}

				next_degat = Time.time + cadence_de_degat;
			}
		}
	}
	
	public void etas()
	{
		etas1 = false;
		timeetas = 4 + Time.time; 
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookradius); 
	}
	
}
