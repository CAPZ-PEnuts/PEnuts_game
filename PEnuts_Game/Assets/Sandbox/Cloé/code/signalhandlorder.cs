using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signalhandlorder : MonoBehaviour {
    public boutton[] mybut;
    public GameObject porte; 
    private int i = 0; 


	// Use this for initialization
	/*void Start () {
        Debug.Log("Prout3");
        for (int i = 0; i < nbelmt; i++)
            bouttons.Push(mybut[i]);
	}*/

    public void buttonpush(boutton boutton)
    {
        if (boutton == mybut[i])
            i++;
        if (i == mybut.Length)
            porte.active = !porte.active; 
            
    }
	
	
}
