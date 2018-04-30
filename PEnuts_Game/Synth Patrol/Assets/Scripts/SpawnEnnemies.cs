using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemies : MonoBehaviour
{
    public int nbEnnemies;
    public GameObject player;
    public GameObject ennemy;
    public float SpawnDelay;

    private int nbChilds;
    private bool isSpawning;
    private Quaternion flip;
    private float lastSpawn;
    private bool childSelect;
    private float stopDistance; 
	// Use this for initialization
	void Start ()
    {
        nbChilds = transform.childCount;
        isSpawning = false;
        flip = Quaternion.Euler(0, 180, 0);
        lastSpawn = Time.time - SpawnDelay;
        childSelect = false;
        stopDistance = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isSpawning && nbEnnemies > 0 && Time.time > lastSpawn + SpawnDelay)
        {
            lastSpawn = Time.time;
            Transform spawnPoint = transform.GetChild(0);
            if (childSelect)
                spawnPoint = transform.GetChild(1);
            else
                childSelect = true;
            GameObject clone = Instantiate(ennemy, spawnPoint.position, player.transform.rotation * flip);
            clone.GetComponent<Enemies>().stopDistance = stopDistance;
            nbEnnemies--;
            if (childSelect)
                stopDistance++;
        }
        if (nbEnnemies == 0)
        {
            Destroy(this.gameObject);
        }
        /*if (isSpawning)
            transform.position = player.transform.position;*/
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isSpawning = true;
        }
    }
}
