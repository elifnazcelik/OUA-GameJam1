using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{

    public void GoMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
