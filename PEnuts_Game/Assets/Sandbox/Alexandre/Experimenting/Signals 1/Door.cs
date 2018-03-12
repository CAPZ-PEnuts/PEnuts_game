using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Door : MonoBehaviour
{

	public string signal;
	public GameObject signalHandelerObject;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (signal != null && signalHandelerObject != null)
		{
			SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
			if (signalHandeler != null && signalHandeler.Exists(signal) && gameObject.activeSelf != signalHandeler.GetSignal(signal))
				gameObject.SetActive(!gameObject.activeSelf);
		}
	}
}
