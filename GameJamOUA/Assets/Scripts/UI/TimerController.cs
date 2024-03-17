using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public TextMeshProUGUI timeCounter;

    public static TimeSpan bestTime = TimeSpan.MaxValue;
    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;

        BeginTimer();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = PlayerPrefs.GetFloat("Timer", 0);
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;    
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            PlayerPrefs.SetFloat("Timer", elapsedTime);
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            String timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
