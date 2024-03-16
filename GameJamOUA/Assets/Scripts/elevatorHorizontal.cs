using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorHorizontal : MonoBehaviour
{
    // Start is called before the first frame update
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
        Vector3 movement = new Vector2(Mathf.PingPong(Time.time * moveSpeed, movementRange * 2) - movementRange,0f);
        transform.position = startingPosition + movement;
    }
}
