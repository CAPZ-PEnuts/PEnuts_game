using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

	public string signal;
	public GameObject signalHandelerObject;
	private int _counter;
	private bool _state;
	private bool _colorUpdated;
	
	// Use this for initialization
	void Start ()
	{
		_colorUpdated = false;
		_counter = 0;
		_state = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_state != _counter > 0)
		{
			if (_counter > 0)
			{
				FindObjectOfType<AudioManager>().Play("signalclique");
			}
			
			_state = !_state;
			if (signal != null)
			{
				SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
				if (signalHandeler != null)
				{
					if (!signalHandeler.Exists(signal))
						signalHandeler.AddSignal(signal,_state);
					else
						signalHandeler.SetSignal(signal,_state);
				}
			}
		}

		if (_counter > 0)
		{
			_counter--;
			
		}

		if (!_colorUpdated)
		{
			_colorUpdated = true;
			gameObject.GetComponent<Renderer>().material.color = signalHandelerObject.GetComponent<SignalHandeler>().GetSignalColor(signal);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		_counter = 10;
	}

	private void OnTriggerExit(Collider other)
	{
		FindObjectOfType<AudioManager>().Play("sortiePP");
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
