using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShootMulti : NetworkBehaviour
{
    [SyncVar]
    public float speed;
    private double timeSpawn;
    public GameObject playerobj;
    public float timebeforedestroy;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CharacterController player = playerobj.GetComponent<CharacterController>();
        rb.velocity = transform.up * speed;
        timeSpawn = Network.time;
        if (transform.position.y > 0)
            timebeforedestroy = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if (Network.time - timeSpawn > timebeforedestroy)
        {
            Destroy(this.gameObject);
        }
    }
}