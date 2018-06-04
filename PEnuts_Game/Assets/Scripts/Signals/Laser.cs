using System.Collections;
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

    private bool _colorUpdated;
	
	// Use this for initialization
	void Start ()
	{
		_state = false;
        _colorUpdated = false;
	}
	
	// Update is called once per frame
	void Update()
	{
        if (!_colorUpdated)
        {
            _colorUpdated = true;

            Color color = signalHandelerObject.GetComponent<SignalHandeler>().GetSignalColor(signal);

            laser1.GetComponent<Renderer>().material.SetColor("_Color", color);
            laser2.GetComponent<Renderer>().material.SetColor("_Color", color);
            laser3.GetComponent<Renderer>().material.SetColor("_Color", color);
            laser4.GetComponent<Renderer>().material.SetColor("_Color", color);
            laser5.GetComponent<Renderer>().material.SetColor("_Color", color);
            laser6.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
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
