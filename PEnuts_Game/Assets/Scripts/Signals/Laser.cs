﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public string signal;
	public GameObject signalHandelerObject;
	public GameObject laser1;
	public GameObject laser2;
	public GameObject laser3;
	public GameObject laser4;
	public GameObject laser5;
	public GameObject laser6;

	private bool _state;
	
	// Use this for initialization
	void Start ()
	{
		_state = false;
		
	}
	
	// Update is called once per frame
	void Update()
	{
	}

	private void OnTriggerStay(Collider other)
	{
		if (signal != null && !_state)
		{
			SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
			if (signalHandeler != null)
			{
				_state = true;
				if (!signalHandeler.Exists(signal))
					signalHandeler.AddSignal(signal, true);
				else
					signalHandeler.SetSignal(signal, true);

				laser1.SetActive(false);
				laser2.SetActive(false);
				laser3.SetActive(false);
				laser4.SetActive(false);
				laser5.SetActive(false);
				laser6.SetActive(false);

			}
		}
	}
}