using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{
    public SwingPlatform swingPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            collision.GetComponent<DogController>().jumpForce = 8f;
            swingPlatform.StopSwinging();
        }
    }
}
