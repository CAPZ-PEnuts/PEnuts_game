using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Audio.Google;


public class CORPS : MonoBehaviour
{

	public float Temps = 100;
	private float distancee = 5;
	private GameObject ball;
	public GameObject corps; 
	private void Update()
	{
		if (gameObject.activeInHierarchy && Temps < Time.time) ;
		{
			corps.SetActive(false);
		}
		GameObject[] gameplayer = GameObject.FindGameObjectsWithTag("blueball");
		if (gameplayer.Length != 0)
		{
			distancee = Vector3.Distance(transform.position, gameplayer[0].transform.position);
			ball = gameplayer[0];
			for (int i = 1; i < gameplayer.Length; i++)
				if (distancee > Vector3.Distance(transform.position, gameplayer[i].transform.position))
				{
					distancee = Vector3.Distance(transform.position, gameplayer[i].transform.position);
					ball = gameplayer[i];
				}
		}

		if (distancee < 1)
		{
			Debug.Log("DISAPEAR");
			corps.SetActive(true);
			Temps += Time.time;
		}

	}

}