using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class echap : MonoBehaviour {

    public string scenename;
    public GameObject canvas;
    public GameObject multi; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*
            if (canvas.activeInHierarchy && !(multi.activeInHierarchy))
                SceneManager.LoadScene(scenename);
            else
            {
                canvas.SetActive(true);
                multi.SetActive(false);
            }
            */
            canvas.SetActive(true);
            multi.SetActive(false);
        }
               
	}
}
