using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalHandeler : MonoBehaviour
{

	private static Dictionary<string,int> _signals;
	
	// Use this for initialization
	void Start () {
		_signals = new Dictionary<string, int>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void AddSignal(string name, bool state = false)
	{
		
		if (!_signals.ContainsKey(name))
		{
			_signals.Add(name, state? 1 : 0);
		}
		else
		{
			throw new ArgumentException("SignalHandeler.AddSignal: unable to create signal \"" + name + "\", signal already exist");
		}
	}

	public bool GetSignal(string name)
	{

		if (Exists(name))
		{
			return _signals[name] > 0;
		}
		else
		{
			//Debug.Log("SignalHandeler.GetSignal: signal \"" + name + "\" doesn't exists!");
			return false;
		}
	}

	public bool Exists(string name)
	{
		return _signals.ContainsKey(name);
	}

	/*
	// after some redisiging of the way signals are implemented, Toggle is not really doable anymore for now
	public bool ToggleSignal(string name)
	{
		if (Exists(name))
		{
			if (_signals[name] > 0)
				_signals[name] = 0;
			else
				_signals[name] = 1;
			
			return _signals[name] > 0;
		}
		else
		{
			Debug.Log("SignalHandeler.ToggleSignal: signal \"" + name + "\" doesn't exists!");
			return false;
		}
	}*/

	public void SetSignal(string name, bool state, bool erase = false)
	{
		if (Exists(name))
			if (state && !erase)
				_signals[name]++;
			else if (!erase)
				_signals[name]--;
			else if (erase)
				_signals[name] = state ? 1 : 0;
		else
			Debug.Log("SignalHandeler.SetSignal: signal \"" + name + "\" doesn't exists!");

		if (_signals[name] < 0)
			_signals[name] = 0;
	}
}
