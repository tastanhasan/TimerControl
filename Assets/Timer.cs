using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{

    bool timerActive;
    float currentTimer;

    public float playTime = 0;
    private int seconds = 0;

    public TextMeshProUGUI currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = 0;

       
    }

    // Update is called once per frame
    void Update()
    {

        playTime += Time.deltaTime;
        seconds = (int)(playTime % 60);


        if (seconds ==3 || seconds ==8)
        {

            timerActive = true;

        }


        if (timerActive)
        {
            currentTimer = currentTimer + Time.deltaTime;

        }


        TimeSpan time = TimeSpan.FromSeconds(currentTimer);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartTimer()
    {
     
    }

    public void ResetTimer()
    {
        Debug.Log(currentTimeText.text);
        timerActive = false;
        currentTimer = 0;

    }
}
