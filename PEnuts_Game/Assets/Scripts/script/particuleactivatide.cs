using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class particuleactivatide : MonoBehaviour
{

	public GameObject objetquidisparait;
	public GameObject lesparticule; 
	void Update ()
	{
		if (!(objetquidisparait.activeInHierarchy))
			lesparticule.SetActive(true);
		
	}
}
