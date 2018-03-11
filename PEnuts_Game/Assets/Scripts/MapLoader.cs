using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapLoader : MonoBehaviour {

    private int PlayerID;
    private 

    MapLoader(string file, int playerID)
    {
        bool fileLoaded = false;
        try
        {
            FileStream map = File.Open(file, FileMode.Open);
            fileLoaded = true;
        }
        catch
        {

        }

    }


	// Use this for initialization
	void Start () {
		
	}
    

	
}
