using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] SpriteRenderer boxRender;
    [SerializeField] BoxCollider2D boxCol;
    void Awake()
    {
        boxRender.GetComponent<SpriteRenderer>().enabled = false;
        boxCol.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            boxRender.GetComponent<SpriteRenderer>().enabled = true;
            boxCol.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
