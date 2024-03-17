using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySpawn : MonoBehaviour
{
    public float spawnDestroyDelay = 4;
    public float spawnDestroyInterval = 5;
    void Start()
    {
        InvokeRepeating("DestroySpawn", spawnDestroyDelay, spawnDestroyInterval);
    }
    void DestroySpawn()
    {
        Destroy(gameObject);
    }
}
