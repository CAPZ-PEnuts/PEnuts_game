using System.Collections;
using System.Threading; 
using System.Collections.Generic;
using UnityEngine;

public class boutton : MonoBehaviour {
    public GameObject player;
    public signalhandlorder signal; 

    void OnTriggerEnter(Collider other)
    {
     if (other.gameObject == player)
        //if (Input.GetKeyDown(KeyCode.F))
           signal.buttonpush(this);
    }

}
