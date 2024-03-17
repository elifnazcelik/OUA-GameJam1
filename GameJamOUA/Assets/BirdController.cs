using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Transform target;
    public Transform exitPoint;
    public float speed = 2.5f;
    private bool moveToTarget = false;
    private bool moveExitPoint = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (moveToTarget)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            
            Vector3 direction = target.position - transform.position;
            GetComponent<SpriteRenderer>().flipX = direction.x < 0;
        }
        
        if (moveExitPoint)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, exitPoint.position, step);
            
            Vector3 direction = exitPoint.position - transform.position;
            GetComponent<SpriteRenderer>().flipX = direction.x < 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Man"))
        {
            moveToTarget = true;
            anim.SetTrigger("fly");
        }
        
        if (other.gameObject.CompareTag("Shield"))
        {
            moveToTarget = false;
            moveExitPoint = true;
        }
    }
}
