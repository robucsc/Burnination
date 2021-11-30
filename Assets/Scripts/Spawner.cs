using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject myPrefab;
    public float spawnRate;
    public int spawnCap;
    private Vector3 spawnerPos;

    void Awake()
    {
        // start timer
        spawnRate = Random.Range(20.0f, 40.0f);
        // find spawner pos
        spawnerPos = gameObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnCap > 0)
        {
            // increment timer
            spawnRate -= Time.deltaTime;
            // when spawn timer hits 0, restart timer and spawn entity
            if (spawnRate <= 0.0f)
            {
                Rigidbody2D clone;
                clone = Instantiate(myPrefab, spawnerPos + new Vector3(0.0f, 0.5f, Random.Range(-1.0f, -3.0f)), Quaternion.identity);
                
                spawnRate = Random.Range(20.0f, 40.0f);
                spawnCap -= 1;
            }
        }
        
    }
}
