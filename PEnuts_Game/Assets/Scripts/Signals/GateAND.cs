using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAND : MonoBehaviour
{

	public string signal1;
	public string signal2;
	public string signalOut;
	public GameObject signalHandelerObject;
	private bool status;
	
	void Start ()
	{
		status = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (signal1 != null && signal2 != null && signalOut != null && signalHandelerObject != null)
		{
			SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
			if (signalHandeler != null)
			{
				if (status != (signalHandeler.GetSignal(signal1) && signalHandeler.GetSignal(signal2)))
				{
					status = !status;
					if (!signalHandeler.Exists(signalOut))
						signalHandeler.AddSignal(signalOut,status);
					else
						signalHandeler.SetSignal(signalOut,status);
				}
			}
		}
	}
}
