using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

	public string signal;
	public GameObject signalHandelerObject;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
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
	}
	
	private void OnTriggerExit(Collider other)
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
	}
}
