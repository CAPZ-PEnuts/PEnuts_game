using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour {
    public AudioClip valid;
    public AudioClip selected;
    public float fireRate;
    private float nextFire;
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Joystick1Button0) && Time.time > nextFire)
        {
            GetComponent<AudioSource>().PlayOneShot(valid, 1);
            nextFire = Time.time + fireRate;
        }
    }
    public void SceneManage(int scene)
    {
        SceneManager.LoadScene(scene);
        //SceneManager.UnloadSceneAsync(originalScene);
    }

   
    public void quitGame()
    {
        Application.Quit();
    }

}
