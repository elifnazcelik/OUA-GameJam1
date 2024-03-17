using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            spawnPoint.GetComponent<SpawnManager>().active = false;
        }
    }
}
