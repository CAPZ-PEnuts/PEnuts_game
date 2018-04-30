using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotation : MonoBehaviour {

    public float locX_999ForDefault; 
    public float locY;
    public float locZ;
    public GameObject CameraPlacer;
    public bool isAnimating;

    private CharacterController player;
    private float rotFinalX;
    private float rotFinalY;
    private float rotFinalZ;
    private float initRotY;
    private bool endAnim = false;

    // Use this for initialization
    void Start () {
        player = GetComponent<CharacterController>();
        initRotY = player.transform.localRotation.eulerAngles.y;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 rot = player.transform.localRotation.eulerAngles;
        float rotX = rot.x;
        float rotY = rot.y;
        float rotZ = rot.z;
        if (locX_999ForDefault == 999)
            rotFinalX = rotX;
        else
            rotFinalX = locX_999ForDefault;
        if (locY == 999)
            rotFinalY = rotY;
        else
            rotFinalY = locY + initRotY;
        if (locZ == 999)
            rotFinalZ = rotZ;
        else
            rotFinalZ = locZ;
        player.transform.localRotation = Quaternion.Euler(new Vector3(rotFinalX, rotFinalY, rotFinalZ));
        if (isAnimating)
        {
            endAnim = true;
            CameraPlacer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -rotFinalZ));
        }
        else if(endAnim)
        {
            initRotY = rotY;
            endAnim = false;
        }
	}
}
