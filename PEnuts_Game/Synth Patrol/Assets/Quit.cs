using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button15))
        {
            SceneManager.LoadScene(0);
            //Destroy(player.GetComponent<ScriptableObject>("NetworkManager"));
            SceneManager.UnloadScene(1);
        }
    }
}
