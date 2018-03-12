using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

	public string signal;
	public GameObject signalHandelerObject;
	private int _counter;
	private bool _state;
	
	// Use this for initialization
	void Start ()
	{
		_counter = 0;
		_state = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Updated 1 " + _counter.ToString());
		if (_state != _counter > 0)
		{
			Debug.Log("Updated 2");
			_state = !_state;
			if (signal != null)
			{
				Debug.Log("Updated 3");
				SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
				if (signalHandeler != null)
				{
					Debug.Log("Updated 4");
					if (!signalHandeler.Exists(signal))
						signalHandeler.AddSignal(signal,_state);
					else
						signalHandeler.SetSignal(signal,_state);
				}
			}
		}

		if (_counter > 0)
			_counter--;
	}

	private void OnTriggerStay(Collider other)
	{
		_counter = 60;
	}
/*
	private void OnTriggerEnter(Collider intruder)
	{
		if (intruder)
			if (signal != null)
			{
				SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
				if (signalHandeler != null)
				{
					if (!signalHandeler.Exists(signal))
						signalHandeler.AddSignal(signal,true);
					else
						signalHandeler.SetSignal(signal,true);
				}
			}
	}
	
	private void OnTriggerExit(Collider intruder)
	{
			if (signal != null)
			{
				SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
				if (signalHandeler != null)
				{
					if (!signalHandeler.Exists(signal))
						signalHandeler.AddSignal(signal,true);
					else
						signalHandeler.SetSignal(signal,true);
				}
			}
	}*/
}
