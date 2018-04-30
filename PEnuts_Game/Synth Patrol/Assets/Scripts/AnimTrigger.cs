using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class AnimTrigger : MonoBehaviour
{

    public Animator anim;
    public GameObject canvas;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(1).IsTag("Idle"))
        {
            if (Input.GetKeyDown(KeyCode.B) || (Input.GetKeyDown(KeyCode.Joystick1Button2)))
            {
                anim.Play("Barrel Roll", 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "rTrigger")
        {
            /*Quaternion rotation = new Quaternion();
            rotation.SetLookRotation(transform.right, transform.up); //Crée une rotation qui tourne vers la droite
            Turn(rotation, -1); // Appelle de la fonction pour tourner
            other.gameObject.SetActive(false); // Désactivation du trigger*/
            other.gameObject.SetActive(false);
            anim.Play("Turn Right", 1);
        }
        else if (tag == "EnemyShot")
        {
            other.gameObject.SetActive(false);
            anim.Play("Damage", 1);
        }
        else if (tag == "Level1Turn1")
        {
            other.gameObject.SetActive(false);
            anim.Play("Level1Turn1");
        }
        else if (tag == "Level1Turn2")
        {
            other.gameObject.SetActive(false);
            this.transform.position = new Vector3(-1000, 180, -267);
            this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (tag == "Level1Turn3")
        {
            other.gameObject.SetActive(false);
            this.transform.position = new Vector3(-750, 10, 1858);
            this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (tag == "Acceleration")
        {
            other.gameObject.SetActive(false);
            anim.Play("Acceleration", 2);
        }
        else if (tag == "Brake")
        {
            other.gameObject.SetActive(false);
            anim.Play("Brake", 2);
        }
        else if (tag == "Level1End")
        {
            other.gameObject.SetActive(false);
            canvas.SetActive(true);
        }
        else if (tag == "Level1Quit")
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
