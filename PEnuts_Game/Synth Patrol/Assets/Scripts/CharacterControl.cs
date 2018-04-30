using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterControl : NetworkBehaviour
{
    public float speed;
    public float maxSpeed;

    private CharacterController player;
    private Camera cam;
    private bool canShoot;

    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    public AudioClip shot1;
    public AudioClip shot2;
    public AudioClip shot3;
    public AudioClip shot4;

    private double nextFire;

    void Start ()
    {
        player = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        canShoot = true;
        if (isLocalPlayer)
        {
            if (!cam.enabled)
                cam.enabled = true;
        }
        else
        {
            cam.enabled = false;
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetButton("Fire1") && canShoot)
        {
            CmdFire();
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
        if (Input.GetButtonUp("SpeedUp") && speed > 0)
            speed = speed / 2;
        if (Input.GetButtonUp("SpeedDown") && speed < maxSpeed)
            speed = speed * 2;
    }

    void FixedUpdate ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float lateral = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(0, -vertical, 0);
        Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion fixedRotation = transform.rotation;
        Quaternion angleRotate = Quaternion.AngleAxis(-lateral * 100, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, fixedRotation * rotation * angleRotate, Time.deltaTime);
        player.Move(transform.forward * speed);
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    [Command]
    void CmdFire()
    {
        GameObject clone = Instantiate(shot, shotSpawn.transform.position, transform.rotation * shot.transform.rotation);
        nextFire = Network.time + fireRate;
        NetworkServer.Spawn(clone);
    }
}
