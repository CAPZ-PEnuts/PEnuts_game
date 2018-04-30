using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour {
    public float speed;
    public Rigidbody rb;
    public GameObject spawnPoint;
    private float timeSpawn;
    public float timebeforedestroy;
    public GameObject playerobj;

    private Vector3 pPosition;
    //public CharacterController player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Rigidbody player = playerobj.GetComponent<Rigidbody>();
        //transform.rotation = player.transform.rotation * transform.rotation;
        rb.velocity = player.transform.forward * speed;
        //rb.AddForce(Vector3.forward);
        timeSpawn = Time.time;
        //C'est tres sale
        if (transform.position.y > 0)
        {
            timebeforedestroy = 5;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3.Slerp(pPosition, spawnPoint.transform.position, Time.deltaTime);
        if (Time.time - timeSpawn > timebeforedestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
