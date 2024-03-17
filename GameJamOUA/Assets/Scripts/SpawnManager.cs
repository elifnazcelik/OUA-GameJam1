using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpawnManager : MonoBehaviour
{
    public bool active = true;
    [SerializeField] GameObject _prefab;
    public float spawnDelay = 5;
    public float spawnInterval = 1.5f;
    void Start()
    {
        Invoke("Spawn", spawnInterval);
    }
    void Spawn()
    {
        if (active)
        {
            Vector2 spawnPos = gameObject.transform.position;
            Instantiate(_prefab, spawnPos, _prefab.transform.rotation);
            Invoke("Spawn", spawnInterval);
        }
    }
}
