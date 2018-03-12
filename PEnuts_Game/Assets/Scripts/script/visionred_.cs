using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visionred_ : MonoBehaviour {

    public GameObject bluebox;
    public GameObject redbox;
    public GameObject multi;
    public GameObject canvas;
    private void Start()
    {
        multi.SetActive(false);
    }
    // Use this for initialization
    public void changevision()
    {
        bluebox.SetActive(false);
        redbox.SetActive(true);
        multi.SetActive(true);
        canvas.SetActive(false);
    }
}
