using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawn : MonoBehaviour
{
    public GameObject ennemy;
    public int nbEnnemies;
    public GameObject player;

    private int nbChilds;
    private bool isSpawning;
    private Quaternion flip;

    // Use this for initialization
    void Start ()
    {
        nbChilds = transform.childCount;
        isSpawning = false;
        flip = Quaternion.Euler(0, 180, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isSpawning && nbEnnemies > 0)
        {
            int i = 0;
            while (nbEnnemies > 0 && i < nbChilds)
            {
                Transform spawnPoint = transform.GetChild(i);
                GameObject clone = Instantiate(ennemy, spawnPoint.position, player.transform.rotation * flip);
                nbEnnemies--;
                i++;
            }
        }
        if (nbEnnemies == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isSpawning = true;
        }
    }
}
