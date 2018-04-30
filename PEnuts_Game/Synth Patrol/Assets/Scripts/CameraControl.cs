using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    /* Pour l'instant ça marche pas */
    public GameObject cam;
    public AudioSource Music;
    private Vector3 pos;
    private Quaternion rotLoc;
    private Quaternion rot;

    void Start()
    {
        cam.GetComponent<GameObject>();
        
    }

    void LateUpdate()
    {
        pos = cam.transform.position;
        rot = cam.transform.rotation;
        this.gameObject.transform.SetPositionAndRotation(new Vector3(pos.x, pos.y+2f, pos.z), rot);
        Vector3 locCam = this.gameObject.transform.localRotation.eulerAngles;
        this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(locCam.x, locCam.y, locCam.z));
    }
}