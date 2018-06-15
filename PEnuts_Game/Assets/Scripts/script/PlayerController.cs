using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public bool local = false;

    public GameObject playercolor;
    public GameObject balleprefab;
    public Transform bulletspawn;
    public GameObject bluebox;
    public GameObject redbox;
    public bool condition;
    public float speedmov = 1;
    public float speedjump = 5;
    public float cadence_de_tir = 2f;

    private bool isblu = true;

    private float nextfire = 0f;

    private void Start()
    {
        if(true)
        {
            bool color = GameObject.Find("ColorSelectMenu").GetComponent<ColorSelectMenu>().isblue;
            CmdSetColor(color);
        }
    }
    void Update()
    {
        bool ColorMenuActivated = GameObject.Find("ColorSelectMenu").GetComponent<ColorSelectMenu>().ColorMenuActivated;
        if (!ColorMenuActivated)
        {
            if (local)
            {
                bool color = GameObject.Find("ColorSelectMenu").GetComponent<ColorSelectMenu>().isblue;
                CmdSetColor(color);
                /*
                if (condition)
                {
                    bluebox.SetActive(false);
                }
                else
                {
                    redbox.SetActive(false);
                }
                */
                var z = Input.GetAxis("Horizontal");
                var x = Input.GetAxis("Vertical") * Time.deltaTime * speedmov;
                transform.position += transform.up * Time.deltaTime * speedjump * Input.GetAxis("Jump");
                //transform.Rotate(0, z*90, 0);
                transform.Translate(0, 0, x);
                if (Input.GetButtonDown("Horizontal"))
                {
                    if (z < 0)
                    {
                        transform.Rotate(0, -90, 0);
                    }
                    else
                    {
                        transform.Rotate(0, 90, 0);
                    }
                }


                if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextfire && !PauseMenu.GameIsPaused)
                {
                    nextfire = Time.time + cadence_de_tir;
                    CmdFire();
                    FindObjectOfType<AudioManager>().Play("tirejoueur");
                }
                playercolor.GetComponent<MeshRenderer>().material.color = (color)?Color.blue:Color.red;
            }
            else
            {
                //playercolor.GetComponent<MeshRenderer>().material.color = Color.red;
                playercolor.GetComponent<MeshRenderer>().gameObject.SetActive(false);
            }
        }
    }
    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(balleprefab, bulletspawn.position, bulletspawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15f;
        
        NetworkServer.Spawn(bullet);
        
        bullet.GetComponent<Bullet>().Isbluee = isblu;
        
        Rpcfire(bullet, isblu);
        Destroy(bullet, 2.0f);
       
    }

    [Command]
    void CmdSetColor(bool color)
    {
        RpcSetColor(color);
    }

    [ClientRpc]
    void RpcSetColor(bool color)
    {
       isblu = color;
    }

    [ClientRpc]
    public void Rpcfire(GameObject ball, bool blublu) {
        ball.GetComponent<Bullet>().Isbluee = blublu;
     }

    public void Cmdisblue(bool condition)
    {
        //isblu = condition;
    }
    public override void OnStartLocalPlayer()   
    {
        playercolor.GetComponent<MeshRenderer>().material.color = Color.blue;      
    }
}
