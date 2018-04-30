using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Control_Player : MonoBehaviour
{
    public float initialSpeed;
    public float addSpeed = 0;
    public float rotationSpeed = 0.05f;
    public Text gameOver;
    public Text PressR;
    public Image endBg;

    private Animator anim;
    private CharacterController player;
    private int zDir = 1;
    private bool isRotating = false;
    private Quaternion newRotation;
    private float rotationTime = 0f;
    private bool stop = false;
    private float speed;

    public int health = 3;
    private int maxHealth = 5;
    public Image[] hearts = new Image[5];

    //SHOOT
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    public float shotSpeed;
    public AudioClip shot1;
    public AudioClip shot2;
    public AudioClip shot3;
    public AudioClip shot4;

    private float nextFire;

    void Start ()
    {
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        newRotation = new Quaternion();
    }

    void Update()
    {
        speed = 1 / (initialSpeed - addSpeed);
        if(!stop)
        {
            if ((Input.GetButton("Fire1") || (Input.GetKeyDown(KeyCode.Space))) && Time.time > nextFire)
            {
                GameObject clone = Instantiate(shot, shotSpawn.transform.position, transform.rotation * shot.transform.rotation) as GameObject;
                nextFire = Time.time + fireRate;
                int rand = (int)(Random.value * 4f);
                switch (rand){
                    case 0:
                        clone.GetComponent<AudioSource>().PlayOneShot(shot1);
                        break;
                    case 1:
                        clone.GetComponent<AudioSource>().PlayOneShot(shot2);
                        break;
                    case 2:
                        clone.GetComponent<AudioSource>().PlayOneShot(shot3);
                        break;
                    case 3:
                        clone.GetComponent<AudioSource>().PlayOneShot(shot4);
                        break;
                }
            }
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (health <= 0 || Input.GetKeyUp(KeyCode.T))
        {
            GameOver();
        }
        else
        {
            for(int i = 0; i < 5; i++)
            {
                if(i>=health)
                    hearts[4-i].enabled = false;
                else
                    hearts[4 - i].enabled = true;
            }
        }
    }

    void FixedUpdate ()
    {
        if (!stop)
        {
            if (isRotating)
            {
                rotationTime += rotationSpeed;
                transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationTime);
                if (rotationTime > 1)
                {
                    isRotating = false;
                    rotationTime = 0;
                }
            }
            float lateral = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical"); //Récuperation des inputs
            Vector3 mvtForce = new Vector3(lateral * 0.8f, vertical * 0.7f, 1 );
            mvtForce = transform.TransformVector(mvtForce);
            player.Move(mvtForce * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "crashTrigger")
        {
            health = 0;
        }
        else if(tag == "EnemyShot")
        {
            other.gameObject.SetActive(false);
            health -= 1;
        }
        else if(tag == "LifeBonus")
        {
            other.gameObject.SetActive(false);
            health += 2;
            if (health > 5)
                health = 5;
        }
    }

    private void GameOver()
    {
        PressR.text = "press r to restart";
        gameOver.text = "game over";
        endBg.color = new Color(10 / 255f, 0, 10 / 255f, 1);
        stop = true;
        Time.timeScale = 0;
    }
    /*public void Turn(Quaternion rotation, int directionSetter) // Déclenche une rotation du quaternion avec inversion des coordonées si nécessaire
    {
        zDir = directionSetter * zDir;
        newRotation = rotation;
        isRotating = true;
    }*/
}
