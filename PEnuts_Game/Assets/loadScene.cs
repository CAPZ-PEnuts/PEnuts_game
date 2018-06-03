using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking; 
public class loadScene : NetworkBehaviour
{

    
    public void load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
