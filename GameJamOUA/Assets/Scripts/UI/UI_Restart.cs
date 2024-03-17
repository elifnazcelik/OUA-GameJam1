// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Restart the schene when clicked on UI
public class Restart : MonoBehaviour
{
    // Restart game function
    public void RestartGame()
    {
        Debug.Log("aa");
        SceneManager.LoadSceneAsync("City_Scene_Demo");
    }
}
