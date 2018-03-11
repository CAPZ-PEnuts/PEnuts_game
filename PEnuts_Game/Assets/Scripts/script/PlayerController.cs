using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject balleprefab;
    public Transform bulletspawn;
    public float speedmov = 1;
    public float speedjump = 5;
    void Update()
    {
        if (isLocalPlayer)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * speedmov;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f* speedmov;
            transform.position += transform.up * Time.deltaTime * speedjump * Input.GetAxis("Jump"); 
            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                CmdFire();
            }
        }
    }
    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(balleprefab, bulletspawn.position, bulletspawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2.0f); 
    }
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue; 
    }
}
