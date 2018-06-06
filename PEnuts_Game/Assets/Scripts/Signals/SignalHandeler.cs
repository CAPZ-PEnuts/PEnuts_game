using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalHandeler : MonoBehaviour
{

    public enum SignalColor
    {
        BLUE1,
        RED1,
        YELLOW1,
        GREEN1,
        CYAN1,
        PINK1

    }

    public static Color getColor(SignalColor col)
    {
        Color color = new Color(123, 123, 123);
	    
	    switch (col)
        {
            case SignalColor.BLUE1: 
                color = new Color(0.6117f, 1f, 0.6352f);
                break;
            case SignalColor.RED1:
                color = new Color(0.9176f, 0.6392f, 0.5f);
                break;
            case SignalColor.YELLOW1:
                color = new Color(0.7921f, 0.7960f, 0.1960f);
                break;
            case SignalColor.GREEN1:
                color = new Color(0.4f, 0.5764f, 0);
                break;
            case SignalColor.CYAN1:
                color = new Color(0.3058f, 0.6980f, 0.8392f);
                break;
            case SignalColor.PINK1:
                color = new Color(1, 0.3411f, 0.6705f);
                break;
            default:
	            Debug.Log("WHYYY");
	            break;
        }
	    

        return color;
    }

    private static Dictionary<string, SignalColor> _colors;
	private static Dictionary<string,int> _signals;

    private static List<SignalColor> _colortape;

    private static int _colcount;
	
	// Use this for initialization
	void Start () {
		_signals = new Dictionary<string, int>();
        _colors = new Dictionary<string, SignalColor>();

        _colcount = 0;


        _colortape = new List<SignalColor>();

        _colortape.Add(SignalColor.BLUE1);
        _colortape.Add(SignalColor.RED1);
        _colortape.Add(SignalColor.YELLOW1);
        _colortape.Add(SignalColor.GREEN1);
        _colortape.Add(SignalColor.PINK1);
        _colortape.Add(SignalColor.CYAN1);

    }

    // Update is called once per frame
    void Update () {
		
	}


	public void AddSignal(string name, bool state = false)
	{
		
		if (!_signals.ContainsKey(name))
		{
			_signals.Add(name, state? 1 : 0);
            _colors.Add(name, _colortape[_colcount]);
            _colcount = (_colcount + 1) % 6;
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
            AddSignal(name, false);
            return false;
			//Debug.Log("SignalHandeler.GetSignal: signal \"" + name + "\" doesn't exists!");
		}
	}

    public Color GetSignalColor(string name)
    {
        if (Exists(name))
        {
            return getColor(_colors[name]);
	        
        }
        else
        {
            AddSignal(name, false);
	        return getColor(_colors[name]);
            //Debug.Log("SignalHandeler.GetSignalColor: signal \"" + name + "\" doesn't exists!");
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
