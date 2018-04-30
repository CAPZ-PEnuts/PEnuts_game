using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl_Menu : MonoBehaviour {

    public float speed;
    //public Material grid;
    private float zAxe;
	// Use this for initialization
	void Start () {
        zAxe = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Cursor.visible = false;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zAxe);
        if (this.transform.position.z > 11)
        {
            zAxe = 0;
        } else
        {
            zAxe += speed;
        }
    }
}
