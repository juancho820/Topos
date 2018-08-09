using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    public void SpawnObject()
    {
        GameObject bolita = Instantiate(spawnee, transform.position, transform.rotation);
        bolita.transform.parent = gameObject.transform;
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
