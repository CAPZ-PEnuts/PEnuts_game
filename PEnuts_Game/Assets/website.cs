using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class website : MonoBehaviour {

    public void openUrl(string websiteName)
    {
        Application.OpenURL("http://" + websiteName);
    }
}