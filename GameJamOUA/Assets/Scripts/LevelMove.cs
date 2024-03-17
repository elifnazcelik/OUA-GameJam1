using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    private Scene Forest;

    private void Start()
    {
         Forest= SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog")) 
        {
            Debug.Log("aa");
            SceneManager.LoadScene(Forest.buildIndex + 1);
        }
    }
}
