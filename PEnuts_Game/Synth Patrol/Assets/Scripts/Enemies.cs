using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    public GameObject player;
    public float timeOnScreen;
    public float speed = 100;
    public float stopDistance = 1;

    private float nextFire;
    private Rigidbody rb;
    private Vector3 mvt;
    private int dir;
    private int zDir;
    private float spawnTime;
    private bool isStop;
    private Vector3 playerPos;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        playerPos = transform.InverseTransformPoint(player.transform.position);
        if (playerPos.y > 0)
            dir = 2;
        else
            dir = -2;
        zDir = -1;
        spawnTime = Time.time;
        isStop = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Time.time > nextFire)
        {
            GameObject clone = Instantiate(shot, shotSpawn.transform.position, transform.rotation * shot.transform.rotation) as GameObject;
            //clone.transform.localScale = new Vector3(1, 1, 1);
            clone.transform.SetParent(transform);
            nextFire = Time.time + fireRate;
            clone.transform.position = shotSpawn.transform.position;

            clone.transform.rotation = transform.rotation;
            clone.GetComponent<ShootEnemies>().playerobj = this.gameObject;
        }
        
        
        playerPos = transform.InverseTransformPoint(player.transform.position);
        //Debug.Log(playerPos.y);
        if (playerPos.x * 100 < stopDistance && playerPos.x * 100 > - stopDistance && !isStop)
        {
            dir = 0;
            Vector3 vel = rb.velocity;
            vel.x = 0;
            rb.velocity = vel;
        }

        if (Time.time >= spawnTime + timeOnScreen && !isStop)
        {
            rb.isKinematic = true;
            isStop = true;
        }
        
    }

    void FixedUpdate()
    {
        mvt = new Vector3(dir, 0, zDir);
        rb.AddRelativeForce(mvt * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rWall"))
            dir = -1;
        if (other.CompareTag("lWall"))
            dir = 1;
        if (other.CompareTag("ShootTag"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("OutOfScreen"))
            Destroy(this.gameObject);

    }
}
