using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    [SerializeField] SpriteRenderer boxRender;
    [SerializeField] BoxCollider2D boxCol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            boxRender.GetComponent<SpriteRenderer>().enabled = false;
            boxCol.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
