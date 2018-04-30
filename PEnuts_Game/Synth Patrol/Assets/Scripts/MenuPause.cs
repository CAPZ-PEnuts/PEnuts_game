using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour {
    public GameObject Menu;
    public AudioSource Music;
    public bool isActive;

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            isActive = !isActive;
        }
        menuPause(isActive);
	}

    public void menuPause(bool act)
    {
        if (act)
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
            Music.Pause();
        }
        else
        {
            Menu.SetActive(false);
            Time.timeScale = 1;
            Music.UnPause();
        }
        
    }
    public void quitPause()
    {
        isActive = false;
    }
}
