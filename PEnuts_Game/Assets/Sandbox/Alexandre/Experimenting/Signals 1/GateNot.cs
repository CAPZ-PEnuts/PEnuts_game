using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNot : MonoBehaviour {

	public string signalIn;
	public string signalOut;
	public GameObject signalHandelerObject;
	private bool status;
	
	void Start ()
	{
		status = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (signalIn != null && signalOut != null && signalHandelerObject != null)
		{
			SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
			if (signalHandeler != null)
			{
				if (status != signalHandeler.GetSignal(signalIn))
				{
					status = !status;
					if (!signalHandeler.Exists(signalOut))
						signalHandeler.AddSignal(signalOut,!status);
					else
						signalHandeler.SetSignal(signalOut,!status);
				}
			}
		}
	}
}
