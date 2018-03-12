using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vision : MonoBehaviour {

    public bool condition;
    public GameObject bluebox;
    public GameObject redbox; 
	// Use this for initialization
	void Start ()
    {
        if (condition)
        {
            bluebox.SetActive(false);
        }
        else
        {
            redbox.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (condition)
        {
            bluebox.SetActive(false);
        }
        else
        {
            redbox.SetActive(false);
        }
    }
}
