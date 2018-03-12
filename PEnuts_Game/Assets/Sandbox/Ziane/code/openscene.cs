using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class openscene : MonoBehaviour {
    // Update is called once per frame
	public void Changerdescene()
    {
        //if(!(SceneManager.GetSceneByName("le jeu").isLoaded))
        SceneManager.LoadScene("le jeu");
        /*
        else
        {
            SceneManager.GetActiveScen
        }
        */
	}
}
