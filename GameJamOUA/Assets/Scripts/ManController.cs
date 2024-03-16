using System;
using UnityEngine;

public class ManController : MonoBehaviour
{
    public float speed = 1.0f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            speed = 0;
            anim.SetTrigger("died");
        }
        
        if (other.gameObject.CompareTag("Dog"))
        {
            speed = 0;
            anim.SetBool("isWalking", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            anim.SetBool("isWalking", true);
            speed = 1.0f;
        }
    }
}