using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevator : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float movementRange = 5f;


    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }


    void Update()
    {
        MoveAutomatically();
    }

    void MoveAutomatically()
    {
        Vector3 movement = new Vector2(0f, Mathf.PingPong(Time.time * moveSpeed, movementRange * 2) - movementRange);
        transform.position = startingPosition + movement;
    }
}
