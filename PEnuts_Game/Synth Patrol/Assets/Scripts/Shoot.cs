using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    private float timeSpawn;
    public GameObject playerobj;
    public float timebeforedestroy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CharacterController player = playerobj.GetComponent<CharacterController>();
        //transform.rotation = player.transform.rotation * transform.rotation;
        rb.velocity = player.transform.forward * speed;
        //rb.AddForce(Vector3.forward);
        timeSpawn = Time.time;
        //C'est tres sale
        if(transform.position.y > 0)
        {
            timebeforedestroy = 5;
        }
        
    }
    // Update is called once per frame
    void Update () {
		if(Time.time - timeSpawn > timebeforedestroy)
        {
            Destroy(this.gameObject);
        }
	}
}
