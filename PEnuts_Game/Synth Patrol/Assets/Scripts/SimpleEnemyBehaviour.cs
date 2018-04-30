using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehaviour : MonoBehaviour
{
    public float mvtTime;
    public GameObject shotSpawn;
    public GameObject shot;
    public float fireRate;
    public float speed;

    private Rigidbody rb;
    private float nextFire;
    private bool isStop;
    private float spawnTime;
    private Vector3 mvt;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        isStop = false;
        spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Random.Range(0f, 100f) > 20f && Time.time > nextFire)
        {
            GameObject clone = Instantiate(shot, shotSpawn.transform.position, transform.rotation * shot.transform.rotation) as GameObject;
            clone.transform.SetParent(transform);
            clone.transform.position = shotSpawn.transform.position;
            nextFire = Time.time + fireRate;
            clone.transform.rotation = transform.rotation;
            clone.GetComponent<ShootEnemies>().playerobj = this.gameObject;
        }

        if (Time.time > spawnTime + mvtTime && !isStop)
        {
            rb.isKinematic = true;
            isStop = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isStop)
        {
            mvt = new Vector3(0, -1, 0);
            rb.AddRelativeForce(mvt * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShootTag"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("OutOfScreen"))
            Destroy(this.gameObject);

    }
}
