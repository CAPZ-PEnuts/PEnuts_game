using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemdemerde : MonoBehaviour {
    public GameObject ResumeButton;
    public EventSystem EventSystem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void selectResume()
    {
        EventSystem.SetSelectedGameObject(ResumeButton);
    }
}
