﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

	public string signal;
	public GameObject signalHandelerObject;
	public GameObject doorObject;

	private bool _colorUpdated;
	
	// Use this for initialization
	void Start ()
	{
		_colorUpdated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (signal != null && signalHandelerObject != null && doorObject != null)
		{
			SignalHandeler signalHandeler = signalHandelerObject.GetComponent<SignalHandeler>();
			if (signalHandeler != null /*&& signalHandeler.Exists(signal)*/ && doorObject.activeSelf != !signalHandeler.GetSignal(signal))
				doorObject.SetActive(!doorObject.activeSelf);
			if (!_colorUpdated)
			{
				doorObject.GetComponent<Material>().SetColor("_Color",signalHandelerObject.GetComponent<SignalHandeler>().GetSignalColor(signal));
			}
		}

		
	}
}
