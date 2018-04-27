using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 20 * Time.deltaTime);
        }

        else

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * -20 * Time.deltaTime);
        }

        else

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 20 * Time.deltaTime);
        }

        else

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * -20 * Time.deltaTime);
        }
    }
}
