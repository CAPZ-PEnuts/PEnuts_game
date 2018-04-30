using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStart : MonoBehaviour {
    public float speed;
    public GameObject PressStartMenu;
    public GameObject MainMenu;
    public GameObject EventSystem;
    private float count;
    private bool active;
	// Use this for initialization
	void Start () {
        count = 0;
        active = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.Return))
        {
            MainMenu.gameObject.SetActive(true);
            PressStartMenu.gameObject.SetActive(false);
        }

		if(count > 20)
        {
            count = 0;
        }
        else if (count > 10)
        {
            active = true;
            count += speed;
        }
        else if (count < 10)
        {
            
            count += speed;
        }
    }
}
