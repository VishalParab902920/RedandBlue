using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject spawnee1;
    public GameObject spawnee2;
    public float spawnTime;
    public float spawnDelay;
    public Transform[] spawnPoints;


    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        GameObject spawnee;
        int spawneeID = Random.Range(1, 3);
        if (spawneeID == 1)
            spawnee = spawnee1;
        else
            spawnee = spawnee2;
        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(spawnee, spawnPoints[spawnPointIndex].position, transform.rotation);
    }
}
