using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class deadZone : MonoBehaviour
{
    [SerializeField] GameObject _canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dog") || collision.gameObject.CompareTag("Man"))
        {
            Time.timeScale = 0;
            _canvas.SetActive(true);
        }
    }
}
