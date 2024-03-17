using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Start : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetFloat("Timer", 0);
        SceneManager.LoadSceneAsync("City_Scene_Demo");
    }
}
