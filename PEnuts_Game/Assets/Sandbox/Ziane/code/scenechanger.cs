using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class scenechanger : MonoBehaviour {

    public string scenetogo;

	// Use this for initialization
	void Start () {
		
	}

    public void Changescene()
    {
        //SceneManager.UnloadScene("DontDestroyOnLoad");
        SceneManager.LoadScene(scenetogo);
    }
        
}
