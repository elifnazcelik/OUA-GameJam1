using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

  
    void Start()
    {
        float timer = PlayerPrefs.GetFloat("Timer");
        timerText.text = "Time: " + timer.ToString();
    }
}
